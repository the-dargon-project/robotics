using System.Threading.Tasks;
using Nito.AsyncEx;

namespace Dargon.Robotics.Devices.Common {
   public class AsyncCacheBackedDeviceValue<T> : DeviceValue<T> {
      private readonly AsyncAutoResetEvent valueUpdatedLatch = new AsyncAutoResetEvent();
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