using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using Dargon.Commons;
using Dargon.Robotics.Devices;
using MathNet.Spatial.Euclidean;

namespace Dargon.Robotics.RollbackLogs {
   public interface IStateSnapshotLog<TSnapshot> : IUpdatable {
      bool TryGetInterpolatedSnapshot(DateTime when, out TSnapshot snapshot);
   }

   public interface IMotionStateSnapshotLog : IStateSnapshotLog<MotionSnapshot> {
   }

   public abstract class StateSnapshotLogBase<TSnapshot> : IStateSnapshotLog<TSnapshot> {
      private readonly LinkedList<SnapshotEntry<TSnapshot>> storage = new LinkedList<SnapshotEntry<TSnapshot>>();
      private readonly TimeSpan snapshotCullingExpiration;

      protected StateSnapshotLogBase(TimeSpan snapshotCullingExpiration) {
         this.snapshotCullingExpiration = snapshotCullingExpiration;
      }

      public bool TryGetInterpolatedSnapshot(DateTime when, out TSnapshot snapshot) {
         var current = storage.First;

         // run down list until we reach a node timestamped after when.
         while (current != null && current.Value.Timestamp < when) {
            current = current.Next;
         }

         // if the node doesn't exist or a node doesn't exist before it, fail as we'd have to extrapolate.
         if (current == null || current.Previous == null) {
            snapshot = default(TSnapshot);
            return false;
         }

         // Interpolate between current and the snapshot before it.
         snapshot = InterpolateSnapshots(current.Previous.Value, current.Value, when);
         return true;
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
         storage.AddLast(entry);

         // cull old snapshot entries
         while (storage.Count != 0 && storage.First.Value.Expires < now) {
            storage.RemoveFirst();
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
