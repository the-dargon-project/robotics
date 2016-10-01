using Dargon.Commons;
using Dargon.Robotics.DeviceRegistries;
using Dargon.Robotics.Devices.Components;
using IniParser.Model;
using IniParser.Parser;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DeviceConfigurationLoaderImpl {
      private const string kDeviceConfigurationFileName = "devices.cfg";

      private readonly Dictionary<string, Func<SectionData, IDevice>> deviceLoadersByType;

      private readonly IDeviceFactory deviceFactory;

      public DeviceConfigurationLoaderImpl(IDeviceFactory deviceFactory) {
         this.deviceFactory = deviceFactory;
         this.deviceLoadersByType = new Dictionary<string, Func<SectionData, IDevice>> {
            { "beaglebone.gpio.pwmmotor", LoadGpioMotor },
            { "ghetto_remote.servo", LoadGhettoRemoteServo }
         };
      }

      public void LoadDeviceConfiguration(IDeviceRegistry deviceRegistry) {
         var config = new IniDataParser().Parse(File.ReadAllText(kDeviceConfigurationFileName));
         foreach (var section in config.Sections) {
            var type = section.Keys["type"];
            var device = deviceLoadersByType[type](section);
            deviceRegistry.AddDevice(section.SectionName, device);
         }
      }

      public IDevice LoadGpioMotor(SectionData data) {
         var flipped = data.Keys["flip"].ContainsAny(new[] { "1", "true" }, StringComparison.OrdinalIgnoreCase);
         var tweenFactor = data.Keys.ContainsKey("tweenFactor") ? float.Parse(data.Keys["tweenFactor"]) : 0;
         var speedMultiplier = data.Keys.ContainsKey("speedMultiplier") ? float.Parse(data.Keys["speedMultiplier"]) : 1;
         var motor = deviceFactory.PwmMotor(int.Parse(data.Keys["pin"]), tweenFactor, speedMultiplier, flipped);
         // HACK
         if (data.Keys.ContainsKey("angle")) {
            var device = (DeviceBase)motor;
            var angle = double.Parse(data.Keys["angle"]);
            var vect = Vector2D.YAxis.Rotate(Angle.FromDegrees(angle));
            device.AddComponent(DeviceComponentType.DriveWheelForceVector, new VectorComponent((float)vect.X, (float)vect.Y, 0));
         }
         return motor;
      }

      private IDevice LoadGhettoRemoteServo(SectionData data) {
         return deviceFactory.RemoteServo(
            data.Keys["geturl"],
            data.Keys["seturl"],
            float.Parse(data.Keys["default_angle"]));
      }
   }
}