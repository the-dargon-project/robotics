using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogInputImpl : GpioInputBase, AnalogInput {
      public GpioAnalogInputImpl(string name, DeviceValue<float> voltage) : base(name, voltage) { }
   }
}
