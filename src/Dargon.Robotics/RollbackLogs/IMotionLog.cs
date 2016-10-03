using Dargon.Commons.Collections;
using Dargon.Robotics.Devices;
using MathNet.Spatial.Euclidean;
using System;
using System.Linq;
using SCG = System.Collections.Generic;

namespace Dargon.Robotics.RollbackLogs {
   public interface IStateSnapshotLog<TSnapshot> : IUpdatable {
      bool TryGetInterpolatedSnapshot(DateTime when, out TSnapshot result);
      SCG.IEnumerable<TSnapshot> EnumerateSnapshots();
      SCG.IEnumerable<SnapshotEntry<TSnapshot>> EnumerateSnapshotEntries();
   }

   public interface IMotionStateSnapshotLog : IStateSnapshotLog<MotionSnapshot> {
   }

   public abstract class StateSnapshotLogBase<TSnapshot> : IStateSnapshotLog<TSnapshot> {
      private readonly ConcurrentQueue<SnapshotEntry<TSnapshot>> storage = new ConcurrentQueue<SnapshotEntry<TSnapshot>>();
      private readonly TimeSpan snapshotCullingExpiration;

      protected StateSnapshotLogBase(TimeSpan snapshotCullingExpiration) {
         this.snapshotCullingExpiration = snapshotCullingExpiration;
      }

      public bool TryGetInterpolatedSnapshot(DateTime when, out TSnapshot result) {
         SnapshotEntry<TSnapshot> firstSnapshot = null;
         SnapshotEntry<TSnapshot> secondSnapshot = null;
         foreach (var snapshot in storage) {
            if (snapshot.Timestamp < when) {
               firstSnapshot = snapshot;
            } else {
               secondSnapshot = snapshot;
               break;
            }
         }

         if (firstSnapshot == null || secondSnapshot == null) {
            result = default(TSnapshot);
            return false;
         }
         
         result = InterpolateSnapshots(firstSnapshot, secondSnapshot, when);
         return true;
      }

      public SCG.IEnumerable<TSnapshot> EnumerateSnapshots() {
         return storage.Select(e => e.Snapshot).ToList();
      }

      public SCG.IEnumerable<SnapshotEntry<TSnapshot>> EnumerateSnapshotEntries() {
         return storage.ToList();
      }

      public void Update() {
         var now = DateTime.Now;

         // add new snapshot entry
         var snapshot = TakeSnapshot();
         var entry = new SnapshotEntry<TSnapshot> {
            Snapshot = snapshot,
            Timestamp = now,
            Expires = now + snapshotCullingExpiration
         };
         storage.Enqueue(entry);

         // cull old snapshot entries
         SnapshotEntry<TSnapshot> peekedEntry;
         while (storage.TryPeek(out peekedEntry) && peekedEntry.Expires < now) {
            SnapshotEntry<TSnapshot> throwaway;
            storage.TryDequeue(out throwaway);
         }
      }

      protected abstract TSnapshot TakeSnapshot();
      protected abstract TSnapshot InterpolateSnapshots(SnapshotEntry<TSnapshot> first, SnapshotEntry<TSnapshot> second, DateTime when);
   }

   public class SnapshotEntry<TSnapshot> {
      public TSnapshot Snapshot { get; set; }
      public DateTime Timestamp { get; set; }
      public DateTime Expires { get; set; }
   }

   public class MotionSnapshot {
      public Vector2D Position { get; set; }
      public float Yaw { get; set; }
   }

   public class MotionStateSnapshotLog : StateSnapshotLogBase<MotionSnapshot>, IMotionStateSnapshotLog {
      private readonly IPositionTracker positionTracker;
      private readonly IGyroscope yawGyroscope;

      public MotionStateSnapshotLog(IPositionTracker positionTracker, IGyroscope yawGyroscope, TimeSpan snapshotCullingExpiration) : base(snapshotCullingExpiration) {
         this.positionTracker = positionTracker;
         this.yawGyroscope = yawGyroscope;
      }

      protected override MotionSnapshot TakeSnapshot() {
         return new MotionSnapshot {
            Position = positionTracker.Position,
            Yaw = yawGyroscope.GetAngle()
         };
      }

      protected override MotionSnapshot InterpolateSnapshots(SnapshotEntry<MotionSnapshot> first, SnapshotEntry<MotionSnapshot> second, DateTime when) {
         var firstWeight = (second.Timestamp - when).TotalMilliseconds / (second.Timestamp - first.Timestamp).TotalMilliseconds;
         var secondWeight = 1.0 - firstWeight;
         return new MotionSnapshot {
            Position = first.Snapshot.Position.ScaleBy(firstWeight) + second.Snapshot.Position.ScaleBy(secondWeight),
            Yaw = (float)(first.Snapshot.Yaw * firstWeight + second.Snapshot.Yaw * secondWeight)
         };
      }
   }
}
