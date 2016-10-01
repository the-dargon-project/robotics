using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogInputImpl : GpioInputBase<float>, IAnalogInput {
      public GpioAnalogInputImpl(string name, IDeviceValue<float> value)
         : base(name, DeviceType.AnalogInput, value) { }
   }
}
