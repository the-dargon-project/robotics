using System;
using System.Collections.Generic;
using System.IO;
using Dargon.Robotics.Devices.Common;
using Dargon.Robotics.Devices.Components;
using IniParser.Model;
using IniParser.Parser;
using MathNet.Numerics.LinearAlgebra.Single;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DeviceConfigurationLoaderImpl {
      private const string kDeviceConfigurationFileName = "devices.cfg";

      private readonly Dictionary<string, Func<SectionData, Device>> deviceLoadersByType;

      private readonly DeviceFactory deviceFactory;

      public DeviceConfigurationLoaderImpl(DeviceFactory deviceFactory) {
         this.deviceFactory = deviceFactory;
         this.deviceLoadersByType = new Dictionary<string, Func<SectionData, Device>> {
            { "beaglebone.gpio.pwmmotor", LoadGpioMotor },
            { "ghetto_remote.servo", LoadGhettoRemoteServo }
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
         var motor = deviceFactory.PwmMotor(int.Parse(data.Keys["pin"]));
         // HACK
         if (data.Keys.ContainsKey("angle")) {
            var device = (DeviceBase)motor;
            var angle = double.Parse(data.Keys["angle"]);
            var vect = Vector2D.YAxis.Rotate(Angle.FromDegrees(angle));
            device.AddComponent(DeviceComponentType.DriveWheelForceVector, new VectorComponent((float)vect.X, (float)vect.Y, 0));
         }
         return motor;
      }

      private Device LoadGhettoRemoteServo(SectionData data) {
         return deviceFactory.RemoteServo(
            data.Keys["geturl"],
            data.Keys["seturl"],
            float.Parse(data.Keys["default_angle"]));
      }
   }
}