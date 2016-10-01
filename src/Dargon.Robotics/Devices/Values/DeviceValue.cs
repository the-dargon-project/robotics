namespace Dargon.Robotics.Devices.Values {
   public interface DeviceValue<T> {
      T Get();
      void Set(T value);
   }
}
