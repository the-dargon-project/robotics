using System;
using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class BeagleBoneDeviceFactory : DeviceFactory {
      private readonly DeviceValueFactory deviceValueFactory;

      public BeagleBoneDeviceFactory(DeviceValueFactory deviceValueFactory) {
         this.deviceValueFactory = deviceValueFactory;
      }

      public DigitalOutput DigitalOutput(int pin) {
         return new GpioDigitalOutputImpl(
            $"GPIO_DO_{pin}",
            deviceValueFactory.FromFileCached<bool>(
               BuildPinValuePath(pin),
               DeviceValueAccess.ReadWrite));
      }

      public Motor PwmMotor(string name, int pin) {
         throw new NotImplementedException();
      }

      private string BuildPinRootPath(int pin) => $"/sys/class/gpio/gpio{pin}";
      private string BuildPinValuePath(int pin) => $"{BuildPinRootPath(pin)}/value";
   }
}
