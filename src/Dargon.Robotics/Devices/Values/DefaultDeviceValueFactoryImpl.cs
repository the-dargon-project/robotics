using System;
using System.Net;
using Dargon.Robotics.Devices.Values.Util;

namespace Dargon.Robotics.Devices.Values {
   public class DefaultDeviceValueFactoryImpl : IDeviceValueFactory {
      private readonly WebClient wc = new WebClient();
      private readonly IInternalFileSystemProxy internalFileSystemProxy;

      public DefaultDeviceValueFactoryImpl(IInternalFileSystemProxy internalFileSystemProxy) {
         this.internalFileSystemProxy = internalFileSystemProxy;
      }

      public IDeviceValue<T> FromFile<T>(string path, DeviceValueAccess access) {
         return new FileBackedDeviceValueImpl<T>(path, access, internalFileSystemProxy);
      }

      [Obsolete]
      public IDeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access) {
         return WithCache(FromFile<T>(path, access));
      }

      public IDeviceValue<T> FromHttpBasedResource<T>(string getResourceTemplate, string setResourceTemplate, DeviceValueAccess access) {
         return new SomeHttpBasedResourceBackedDeviceValue<T>(
            wc,
            getResourceTemplate,
            setResourceTemplate,
            access);
      }

      public IDeviceValue<float> WithMultiplierShift(IDeviceValue<float> value, float multiplier, float offset) {
         return new MultiplyShiftDeviceValueImpl(value, multiplier, offset);
      }
      
      public IDeviceValue<T> WithCache<T>(IDeviceValue<T> value) {
         return new CachedDeviceValueImpl<T>(value);
      }

      public IDeviceValue<float> IntToFloatAdapter(IDeviceValue<int> deviceValue, int offset, int multiplier) {
         return new IntegerAsFloatDeviceValueAdapter(deviceValue, offset, multiplier);
      }

      public IDeviceValue<float> TweeningAdapter(IDeviceValue<float> deviceValue, float tweenFactor) {
         var result = new TweeningDeviceValueAdapter(deviceValue, tweenFactor);
         result.Initialize();
         return result;
      }

      public IDeviceValue<T> AsyncCachedBacked<T>(IDeviceValue<T> inner) {
         var result = new AsyncCacheBackedDeviceValue<T>(inner);
         result.Initialize();
         return result;
      }
   }
}