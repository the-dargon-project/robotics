using System.Threading.Tasks;
using Dargon.Commons.AsyncPrimitives;

namespace Dargon.Robotics.Devices.Values {
   public class AsyncCacheBackedDeviceValue<T> : IDeviceValue<T> {
      private readonly AsyncAutoResetLatch valueUpdatedLatch = new AsyncAutoResetLatch();
      private readonly IDeviceValue<T> inner;
      private T value;

      public AsyncCacheBackedDeviceValue(IDeviceValue<T> inner) {
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
         value = newValue;
         valueUpdatedLatch.Set();
      }
   }
}