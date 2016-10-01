using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioMotorImpl : GpioOutputBase<float>, IMotor {
      public GpioMotorImpl(string name, IDeviceValue<float> value) : base(name, DeviceType.Motor, value) { }
   }
}
