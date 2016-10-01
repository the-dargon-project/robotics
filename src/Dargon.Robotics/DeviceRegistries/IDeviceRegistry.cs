using System.Collections.Generic;
using Dargon.Robotics.Devices;

namespace Dargon.Robotics.DeviceRegistries {
   public interface IDeviceRegistry {
      void AddDevice(string alias, IDevice device);
      T GetDevice<T>(string alias = null);
      IEnumerable<IDevice> EnumerateDevices();
   }
}
