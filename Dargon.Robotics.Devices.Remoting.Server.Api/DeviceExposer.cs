using Dargon.Services;
using ItzWarty;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Dargon.Robotics.Devices.Remoting.Server {
   public class DeviceExposer {
      private readonly ServiceClient serviceClient;
      private readonly DeviceRegistry deviceRegistry;

      public DeviceExposer(ServiceClient serviceClient,  DeviceRegistry deviceRegistry) {
         this.serviceClient = serviceClient;
         this.deviceRegistry = deviceRegistry;
      }

      public void ExposeDevices() {
         var md5 = MD5.Create();
         foreach (var device in deviceRegistry.EnumerateDevices()) {
            var deviceGuid = new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(device.Name)).SubArray(16));
            serviceClient.RegisterService(device, device.GetType(), deviceGuid);
         }
      }
   }
}
