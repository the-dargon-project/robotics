using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioDigitalOutputImpl : GpioOutputBase<bool>, DigitalOutput {
      public GpioDigitalOutputImpl(string name, IDeviceValue<bool> value) : base(name, DeviceType.DigitalOutput, value) {}
   }
}
