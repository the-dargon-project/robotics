using System.Collections.Generic;

namespace Dargon.Robotics.Devices {
   public interface DeviceRegistry {
      void AddDevice(Device device);
      T GetDevice<T>(string name = null);
      IEnumerable<Device> EnumerateDevices();
   }
}
