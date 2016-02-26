using System;

namespace Dargon.Robotics.Devices.Common {
   public class DefaultDeviceValueFactoryImpl : DeviceValueFactory {
      public DeviceValue<T> FromFile<T>(string path, DeviceValueAccess access) {
         return new FileBackedDeviceValueImpl<T>(path, access);
      }

      [Obsolete]
      public DeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access) {
         return WithCache(FromFile<T>(path, access));
      }

      public DeviceValue<float> WithMultiplierShift(DeviceValue<float> value, float multiplier, float offset) {
         return new MultiplyShiftDeviceValueImpl(value, multiplier, offset);
      }

      public DeviceValue<T> WithCache<T>(DeviceValue<T> value) {
         return new CachedDeviceValueImpl<T>(value);
      }

      public DeviceValue<float> IntToFloatAdapter(DeviceValue<int> deviceValue, int offset, int multiplier) {
         return new IntegerAsFloatDeviceValueAdapter(deviceValue, offset, multiplier);
      }
   }
}