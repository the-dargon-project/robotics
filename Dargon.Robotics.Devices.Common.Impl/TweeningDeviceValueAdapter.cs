using System;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Dargon.Robotics.Devices.Common {
   public class TweeningDeviceValueAdapter : DeviceValue<float> {
      private readonly object sync = new object();
      private readonly DeviceValue<float> deviceValue;
      private readonly float tweenFactor;
      private readonly float invTweenFactor;

      private readonly AsyncAutoResetEvent updateLatch = new AsyncAutoResetEvent();
      private int kStepIntervalMillis = 10;
      private float desiredValue = 0;
      private float actualValue = 0;
      private bool isAnimating = false;

      public TweeningDeviceValueAdapter(DeviceValue<float> deviceValue, float tweenFactor) {
         this.deviceValue = deviceValue;
         this.tweenFactor = tweenFactor;
         this.invTweenFactor = 1 - tweenFactor;
      }

      public void Initialize() {
         RunAsync().ConfigureAwait(false);
      }

      private async Task RunAsync() {
         while (true) {
            await updateLatch.WaitAsync();
            while (Math.Abs(actualValue - desiredValue) >= 0.02) {
               lock (sync) {
                  actualValue = actualValue * tweenFactor + desiredValue * invTweenFactor;
                  deviceValue.Set(actualValue);
               }
               await Task.Delay(kStepIntervalMillis);
            }
         }
      }

      public float Get() {
         lock (sync) {
            return desiredValue;
         }
      }

      public void Set(float value) {
         lock (sync) {
            desiredValue = value;
            updateLatch.Set();
         }
      }
   }
}