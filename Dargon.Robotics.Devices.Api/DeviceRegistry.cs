using ItzWarty.Collections;

namespace Dargon.Robotics.Devices {
   public interface DeviceRegistry {
      void AddDevice(Device device);
      T GetDevice<T>(string name = null);
      IReadOnlySet<Device> EnumerateDevices();
   }
}
