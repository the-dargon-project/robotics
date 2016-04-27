using Dargon.Robotics.Devices.Common;
using ItzWarty;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class BeagleBoneDeviceFactory : DeviceFactory {
      private readonly DeviceValueFactory deviceValueFactory;
      private readonly IBeagleBoneGpioMotorDeviceFactory gpioMotorDeviceFactory;

      public BeagleBoneDeviceFactory(DeviceValueFactory deviceValueFactory, IBeagleBoneGpioMotorDeviceFactory gpioMotorDeviceFactory) {
         this.deviceValueFactory = deviceValueFactory;
         this.gpioMotorDeviceFactory = gpioMotorDeviceFactory;
      }

      public DigitalOutput DigitalOutput(int pin) {
         return new GpioDigitalOutputImpl(
            $"GPIO_DO_{pin}",
            deviceValueFactory.FromFileCached<bool>(
               BuildPinValuePath(pin),
               DeviceValueAccess.ReadWrite));
      }

      public Motor PwmMotor(int pin) => gpioMotorDeviceFactory.PwmMotor(pin);

      public Servo RemoteServo(string getUrl, string setUrl, float defaultAngle) {
         var angleValue = deviceValueFactory.FromHttpBasedResource<float>(getUrl, setUrl, DeviceValueAccess.ReadWrite);
         return new GhettoRemoteServo(
            "REMOTE_SERVO @ " + getUrl,
            angleValue,
            defaultAngle).With(x => x.Initialize());
      }

      private string BuildPinRootPath(int pin) => $"/sys/class/gpio/gpio{pin}";
      private string BuildPinValuePath(int pin) => $"{BuildPinRootPath(pin)}/value";
   }
}
