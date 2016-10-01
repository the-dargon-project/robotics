using System.Threading.Tasks;
using Dargon.Commons.AsyncPrimitives;

namespace Dargon.Robotics.Devices.Values {
   public class AsyncCacheBackedDeviceValue<T> : DeviceValue<T> {
      private readonly AsyncAutoResetLatch valueUpdatedLatch = new AsyncAutoResetLatch();
      private readonly DeviceValue<T> inner;
      private T value;

      public AsyncCacheBackedDeviceValue(DeviceValue<T> inner) {
         this.inner = inner;
      }

      public void Initialize() {
         value = inner.Get();
         RunAsync().ConfigureAwait(false);
      }

      private async Task RunAsync() {
         while (true) {
            await valueUpdatedLatch.WaitAsync();
            inner.Set(value);
         }
      }

      public T Get() => value;

      public void Set(T newValue) {
         this.value = newValue;
         valueUpdatedLatch.Set();
      }
   }
}