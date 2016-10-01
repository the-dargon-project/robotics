using System.Collections.Generic;
using Dargon.Robotics.Devices;

namespace Dargon.Robotics.DeviceRegistries {
   public interface DeviceRegistry {
      void AddDevice(string alias, Device device);
      T GetDevice<T>(string alias = null);
      IEnumerable<Device> EnumerateDevices();
   }
}
