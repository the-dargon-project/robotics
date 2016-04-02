using Dargon.Robotics.Devices.Common;
using Dargon.Robotics.Devices.Common.Util;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Dargon.Robotics.Devices.BeagleBone {
   public interface IBeagleBoneGpioMotorDeviceFactory {
      Motor PwmMotor(int pin);
   }

   public class BeagleBoneGpioMotorDeviceFactoryImpl : IBeagleBoneGpioMotorDeviceFactory {
      private const string kPwmExportPath = "/sys/class/pwm/export";
      private const string kDutyNanosecondsKey = "duty_ns";
      private const string kPeriodNanosecondsKey = "period_ns";
      private const string kRunKey = "run";
      private const int kPwmCyclePeriod = 2000000;

      private static readonly IReadOnlyDictionary<int, string> kPwmPinNameByExportNumber = new Dictionary<int, string> {
         [0] = "P9_22",
         [1] = "P9_21",
         [2] = "P9_42",
         [3] = "P9_14",
         [4] = "P9_16",
         [5] = "P8_19",
         [6] = "P8_13",
         [7] = "P9_28"
      };

      private readonly IBeagleBoneGpioConfigurationManager beagleBoneGpioConfigurationManager;
      private readonly DeviceValueFactory deviceValueFactory;
      private readonly IInternalFileSystemProxy internalFileSystemProxy;

      public BeagleBoneGpioMotorDeviceFactoryImpl(IBeagleBoneGpioConfigurationManager beagleBoneGpioConfigurationManager, DeviceValueFactory deviceValueFactory, IInternalFileSystemProxy internalFileSystemProxy) {
         this.beagleBoneGpioConfigurationManager = beagleBoneGpioConfigurationManager;
         this.deviceValueFactory = deviceValueFactory;
         this.internalFileSystemProxy = internalFileSystemProxy;
      }

      public Motor PwmMotor(int pin) {
         string pinName = kPwmPinNameByExportNumber[pin];
         beagleBoneGpioConfigurationManager.SetPinMode(pinName, PinMode.Pwm);

         if (!Directory.Exists(BuildPinPath(pin))) {
            internalFileSystemProxy.WriteText(kPwmExportPath, pin.ToString());
         }

         internalFileSystemProxy.WriteText(
            BuildPinPath(pin, kRunKey),
            "0");

         internalFileSystemProxy.WriteText(
            BuildPinPath(pin, kPeriodNanosecondsKey), 
            kPwmCyclePeriod.ToString());

         internalFileSystemProxy.WriteText(
            BuildPinPath(pin, kRunKey), 
            "1");

         var dutyValue = deviceValueFactory.FromFile<int>(
            BuildPinPath(pin, kDutyNanosecondsKey),
            DeviceValueAccess.ReadWrite);

         dutyValue.Set(1500000);
         Thread.Sleep(1000);
         dutyValue.Set(0);
         Thread.Sleep(1000);
         dutyValue.Set(1500000);

         return new GpioMotorImpl(
            $"PWM_Pin{pin}_{pinName}",
            deviceValueFactory.IntToFloatAdapter(
               dutyValue,
               -1500000,
                 399000 // accounts for rounding error
               ));
      }

      private string BuildPinPath(int pin, string key = "") => $"/sys/class/pwm/pwm{pin}/{key}";
   }
}
