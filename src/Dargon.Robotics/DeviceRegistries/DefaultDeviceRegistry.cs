using Dargon.Commons;
using Dargon.Commons.Collections;
using Dargon.Robotics.Devices;
using SCG = System.Collections.Generic;

namespace Dargon.Robotics.DeviceRegistries {
   public class DefaultDeviceRegistry : DeviceRegistry {
      private readonly ConcurrentSet<Device> devices = new ConcurrentSet<Device>(); 
      private readonly ConcurrentDictionary<string, Device> devicesByAlias = new ConcurrentDictionary<string, Device>();
      private readonly ConcurrentDictionary<DeviceType, Commons.Collections.ISet<Device>> devicesByType = new ConcurrentDictionary<DeviceType, Commons.Collections.ISet<Device>>();

      public void AddDevice(string alias, Device device) {
         devices.TryAdd(device);
         devicesByAlias.AddOrUpdate(
            alias,
            add => device,
            (update, existing) => { throw new NameConflictExeption(alias, device.Name); });
         devicesByType.AddOrUpdate(
            device.Type,
            add => new Commons.Collections.HashSet<Device> { device },
            (update, existing) => existing.With(x => x.Add(device))
         );
      }

      public T GetDevice<T>(string alias = null) {
         Device result;
         if (!devicesByAlias.TryGetValue(alias, out result)) {
            throw new SCG.KeyNotFoundException($"Device of alias '{alias}' not registered!");
         }
         return (T)result;
      }

      public SCG.IEnumerable<Device> EnumerateDevices() {
         return devices;
      }
   }
}
