using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioMotorImpl : GpioOutputBase<float>, Motor {
      public GpioMotorImpl(string name, DeviceValue<float> value) : base(name, DeviceType.Motor, value) { }
   }
}
