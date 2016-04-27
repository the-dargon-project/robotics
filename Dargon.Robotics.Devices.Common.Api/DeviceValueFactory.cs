namespace Dargon.Robotics.Devices.Common {
   public interface DeviceValueFactory {
      DeviceValue<T> FromFile<T>(string path, DeviceValueAccess access);
      DeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access);
      DeviceValue<T> FromHttpBasedResource<T>(string getResourceTemplate, string setResourceTemplate, DeviceValueAccess access);
      DeviceValue<float> WithMultiplierShift(DeviceValue<float> value, float multiplier, float offset);
      DeviceValue<T> WithCache<T>(DeviceValue<T> value);
      DeviceValue<float> IntToFloatAdapter(DeviceValue<int> deviceValue, int offset, int multiplier);
   }
}
