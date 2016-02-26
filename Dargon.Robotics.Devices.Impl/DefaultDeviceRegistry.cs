using ItzWarty;
using ItzWarty.Collections;
using System.Data;
using SCG = System.Collections.Generic;

namespace Dargon.Robotics.Devices {
   public class DefaultDeviceRegistry : DeviceRegistry {
      private readonly ConcurrentSet<Device> devices = new ConcurrentSet<Device>(); 
      private readonly ConcurrentDictionary<string, Device> devicesByAlias = new ConcurrentDictionary<string, Device>();
      private readonly ConcurrentDictionary<DeviceType, ISet<Device>> devicesByType = new ConcurrentDictionary<DeviceType, ISet<Device>>();

      public void AddDevice(string alias, Device device) {
         devices.TryAdd(device);
         devicesByAlias.AddOrUpdate(
            alias,
            add => device,
            (update, existing) => { throw new DuplicateNameException($"Device of alias already registered: {alias} (True Name: {device.Name})"); });
         devicesByType.AddOrUpdate(
            device.Type,
            add => new HashSet<Device> { device },
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
