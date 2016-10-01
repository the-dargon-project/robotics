namespace Dargon.Robotics.Devices.Values {
   public interface IDeviceValue<T> {
      T Get();
      void Set(T value);
   }
}
