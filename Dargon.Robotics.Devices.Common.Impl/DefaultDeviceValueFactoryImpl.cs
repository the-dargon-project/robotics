namespace Dargon.Robotics.Devices.Common {
   public class DefaultDeviceValueFactoryImpl : DeviceValueFactory {
      public DeviceValue<T> FromFile<T>(string path, DeviceValueAccess access) {
         return new FileBackedDeviceValueImpl<T>(path, access);
      }

      public DeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access) {
         return new CachedDeviceValueImpl<T>(FromFile<T>(path, access));
      }
   }
}