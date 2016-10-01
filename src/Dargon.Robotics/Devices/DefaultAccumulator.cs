using System.Diagnostics;

namespace Dargon.Robotics.Devices {
   public class DefaultAccumulator : DeviceBase, Accumulator {
      private readonly Stopwatch stopwatch = new Stopwatch();
      private readonly AnalogInput source;
      private float accumulatedValue;

      public DefaultAccumulator(string name, AnalogInput source) : base(name, DeviceType.Accumulator) {
         this.source = source;
      }

      public void Initialize() {
         stopwatch.Start();
      }

      public void Update() {
         var dt = stopwatch.Elapsed.TotalSeconds;
         if (dt < double.Epsilon) {
            return;
         }
         stopwatch.Restart();

         var value = source.Get();
         accumulatedValue += (float)(dt * value);
      }

      public float Get() => accumulatedValue;
   }
}