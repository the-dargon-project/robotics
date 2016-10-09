using Dargon.Commons;
using Dargon.Commons.Collections;
using Dargon.Robotics.Devices;
using SCG = System.Collections.Generic;

namespace Dargon.Robotics.DeviceRegistries {
   public class DefaultDeviceRegistry : IDeviceRegistry {
      private readonly ConcurrentSet<IDevice> devices = new ConcurrentSet<IDevice>();
      private readonly ConcurrentSet<IUpdatableDevice> updatableDevices = new ConcurrentSet<IUpdatableDevice>();
      private readonly ConcurrentDictionary<string, IDevice> devicesByAlias = new ConcurrentDictionary<string, IDevice>();
      private readonly ConcurrentDictionary<DeviceType, ISet<IDevice>> devicesByType = new ConcurrentDictionary<DeviceType, ISet<IDevice>>();

      public void AddDevice(string alias, IDevice device) {
         devices.TryAdd(device);
         if (device is IUpdatableDevice) {
            updatableDevices.AddOrThrow((IUpdatableDevice)device);
         }
         devicesByAlias.AddOrUpdate(
            alias,
            add => device,
            (update, existing) => { throw new NameConflictExeption(alias, device.Name); });
         devicesByType.AddOrUpdate(
            device.Type,
            add => new HashSet<IDevice> { device },
            (update, existing) => existing.With(x => x.Add(device))
         );
      }

      public T GetDevice<T>(string alias = null) {
         IDevice result;
         if (!devicesByAlias.TryGetValue(alias, out result)) {
            throw new SCG.KeyNotFoundException($"Device of alias '{alias}' not registered!");
         }
         return (T)result;
      }

      public SCG.IEnumerable<IDevice> EnumerateDevices() {
         return devices;
      }

      public SCG.IEnumerable<IUpdatableDevice> EnumerateUpdatableDevices() {
         return updatableDevices;
      }
   }
}
