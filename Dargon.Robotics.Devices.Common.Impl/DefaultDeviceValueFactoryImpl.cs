using System;
using System.Net;
using Dargon.Robotics.Devices.Common.Util;

namespace Dargon.Robotics.Devices.Common {
   public class DefaultDeviceValueFactoryImpl : DeviceValueFactory {
      private readonly WebClient wc = new WebClient();
      private readonly IInternalFileSystemProxy internalFileSystemProxy;

      public DefaultDeviceValueFactoryImpl(IInternalFileSystemProxy internalFileSystemProxy) {
         this.internalFileSystemProxy = internalFileSystemProxy;
      }

      public DeviceValue<T> FromFile<T>(string path, DeviceValueAccess access) {
         return new FileBackedDeviceValueImpl<T>(path, access, internalFileSystemProxy);
      }

      [Obsolete]
      public DeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access) {
         return WithCache(FromFile<T>(path, access));
      }

      public DeviceValue<T> FromHttpBasedResource<T>(string getResourceTemplate, string setResourceTemplate, DeviceValueAccess access) {
         return new SomeHttpBasedResourceBackedDeviceValue<T>(
            wc,
            getResourceTemplate,
            setResourceTemplate,
            access);
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