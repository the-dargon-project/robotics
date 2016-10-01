using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioAnalogOutputImpl : GpioOutputBase<float>, IAnalogOutput {
      public GpioAnalogOutputImpl(string name, IDeviceValue<float> value) : base(name, DeviceType.AnalogOutput, value) { }
   }
}