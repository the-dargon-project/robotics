using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogInputImpl : GpioInputBase<float>, AnalogInput {
      public GpioAnalogInputImpl(string name, DeviceValue<float> value)
         : base(name, DeviceType.AnalogInput, value) { }
   }
}
