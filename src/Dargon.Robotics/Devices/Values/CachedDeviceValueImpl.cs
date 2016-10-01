namespace Dargon.Robotics.Devices.Values {
   public class CachedDeviceValueImpl<T> : DeviceValue<T> {
      private readonly DeviceValue<T> backing;
      private T cachedValue;

      public CachedDeviceValueImpl(DeviceValue<T> backing) {
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
