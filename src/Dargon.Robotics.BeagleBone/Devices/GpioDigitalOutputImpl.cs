using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioDigitalOutputImpl : GpioOutputBase<bool>, DigitalOutput {
      public GpioDigitalOutputImpl(string name, DeviceValue<bool> value) : base(name, DeviceType.DigitalOutput, value) {}
   }
}
