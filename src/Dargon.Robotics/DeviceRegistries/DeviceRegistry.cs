using System.Collections.Generic;

namespace Dargon.Robotics.Devices {
   public interface DeviceRegistry {
      void AddDevice(string alias, Device device);
      T GetDevice<T>(string alias = null);
      IEnumerable<Device> EnumerateDevices();
   }
}
