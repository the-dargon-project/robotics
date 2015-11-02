using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogOutputImpl : GpioOutputBase<float>, AnalogOutput {
      public GpioAnalogOutputImpl(string name, DeviceValue<float> value) : base(name, value) { }

      public override DeviceType Type => DeviceType.AnalogOutput;
   }
}