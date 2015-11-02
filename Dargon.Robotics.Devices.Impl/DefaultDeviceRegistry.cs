using ItzWarty;
using ItzWarty.Collections;
using System.Data;

namespace Dargon.Robotics.Devices {
   public class DefaultDeviceRegistry : DeviceRegistry {
      private readonly ConcurrentSet<Device> devices = new ConcurrentSet<Device>(); 
      private readonly ConcurrentDictionary<string, Device> devicesByName = new ConcurrentDictionary<string, Device>();
      private readonly ConcurrentDictionary<DeviceType, ISet<Device>> devicesByType = new ConcurrentDictionary<DeviceType, ISet<Device>>();

      public void AddDevice(Device device) {
         devices.TryAdd(device);
         if (!string.IsNullOrWhiteSpace(device.Name)) {
            devicesByName.AddOrUpdate(
               device.Name,
               add => device,
               (update, existing) => { throw new DuplicateNameException($"Device of name already registered: {device.Name}"); });
         }
         devicesByType.AddOrUpdate(
            device.Type,
            add => new HashSet<Device> { device },
            (update, existing) => existing.With(x => x.Add(device))
         );
      }

      public T GetDevice<T>(string name = null) {
         return (T)devicesByName[name];
      }

      public IReadOnlySet<Device> EnumerateDevices() {
         return devices;
      }
   }
}
