namespace Dargon.Robotics.Devices.Values {
   public class CachedDeviceValueImpl<T> : IDeviceValue<T> {
      private readonly IDeviceValue<T> backing;
      private T cachedValue;

      public CachedDeviceValueImpl(IDeviceValue<T> backing) {
         this.backing = backing;
         this.cachedValue = backing.Get();
      }

      public T Get() => cachedValue;

      public void Set(T value) {
         if (!value.Equals(cachedValue)) {
            cachedValue = value;
            backing.Set(value);
         }
      }
   }
}
