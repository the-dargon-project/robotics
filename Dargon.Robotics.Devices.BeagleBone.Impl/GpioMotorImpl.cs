using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioMotorImpl : GpioOutputBase, Motor {
      public GpioMotorImpl(string name, DeviceValue<float> voltage) : base(name, voltage) { }
   }
}
