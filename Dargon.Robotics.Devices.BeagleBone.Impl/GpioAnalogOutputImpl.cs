using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogOutputImpl : GpioOutputBase, AnalogOutput {
      public GpioAnalogOutputImpl(string name, DeviceValue<float> voltage) : base(name, voltage) { }
   }
}