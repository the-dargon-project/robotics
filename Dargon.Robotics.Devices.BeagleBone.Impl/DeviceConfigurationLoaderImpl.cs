using System;
using System.Collections.Generic;
using System.IO;
using IniParser.Model;
using IniParser.Parser;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DeviceConfigurationLoaderImpl {
      private const string kDeviceConfigurationFileName = "devices.cfg";

      private readonly Dictionary<string, Func<SectionData, Device>> deviceLoadersByType;

      private readonly DeviceFactory deviceFactory;

      public DeviceConfigurationLoaderImpl(DeviceFactory deviceFactory) {
         this.deviceFactory = deviceFactory;
         this.deviceLoadersByType = new Dictionary<string, Func<SectionData, Device>> {
            { "beaglebone.gpio.pwmmotor", LoadGpioMotor }
         };
      }

      public void LoadDeviceConfiguration(DeviceRegistry deviceRegistry) {
         var config = new IniDataParser().Parse(File.ReadAllText(kDeviceConfigurationFileName));
         foreach (var section in config.Sections) {
            var type = section.Keys["type"];
            var device = deviceLoadersByType[type](section);
            deviceRegistry.AddDevice(section.SectionName, device);
         }
      }

      public Device LoadGpioMotor(SectionData data) {
         return deviceFactory.PwmMotor(int.Parse(data.Keys["pin"]));
      }
   }
}