namespace Dargon.Robotics.Devices.Common {
   public interface DeviceValueFactory {
      DeviceValue<T> FromFile<T>(string path, DeviceValueAccess access);
      DeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access);
   }
}
