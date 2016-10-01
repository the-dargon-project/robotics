namespace Dargon.Robotics.Devices.Values {
   public interface IDeviceValueFactory {
      IDeviceValue<T> FromFile<T>(string path, DeviceValueAccess access);
      IDeviceValue<T> FromFileCached<T>(string path, DeviceValueAccess access);
      IDeviceValue<T> FromHttpBasedResource<T>(string getResourceTemplate, string setResourceTemplate, DeviceValueAccess access);
      IDeviceValue<float> WithMultiplierShift(IDeviceValue<float> value, float multiplier, float offset);
      IDeviceValue<T> WithCache<T>(IDeviceValue<T> value);
      IDeviceValue<float> IntToFloatAdapter(IDeviceValue<int> deviceValue, int offset, int multiplier);
      IDeviceValue<float> TweeningAdapter(IDeviceValue<float> deviceValue, float tweenFactor);
      IDeviceValue<T> AsyncCachedBacked<T>(IDeviceValue<T> inner);
   }
}
