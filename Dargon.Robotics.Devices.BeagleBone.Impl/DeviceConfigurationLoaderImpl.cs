using System;
using System.Collections.Generic;
using IniParser.Model;
using IniParser.Parser;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DeviceConfigurationLoaderImpl {
      private const string kDeviceConfigurationFileName = "devices.cfg";

      private readonly Dictionary<string, Func<SectionData, Device>> deviceLoadersByType;

      private readonly BeagleBoneDeviceFactory beagleBoneDeviceFactory;

      public DeviceConfigurationLoaderImpl(BeagleBoneDeviceFactory beagleBoneDeviceFactory) {
         this.beagleBoneDeviceFactory = beagleBoneDeviceFactory;
         this.deviceLoadersByType = new Dictionary<string, Func<SectionData, Device>> {
            { "beaglebone.gpio.pwmmotor", LoadGpioMotor }
         };
      }

      public void LoadDeviceConfiguration(DeviceRegistry deviceRegistry) {
         var config = new IniDataParser().Parse(kDeviceConfigurationFileName);
         foreach (var section in config.Sections) {
            var type = section.Keys["type"];
            var device = deviceLoadersByType[type](section);
            deviceRegistry.AddDevice(device);
         }
      }

      public Device LoadGpioMotor(SectionData data) {
         return beagleBoneDeviceFactory.PwmMotor(data.SectionName, int.Parse(data.Keys["pin"]));
      }
   }
}