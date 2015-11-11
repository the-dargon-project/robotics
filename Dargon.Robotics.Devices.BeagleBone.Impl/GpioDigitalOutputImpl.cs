using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioDigitalOutputImpl : GpioOutputBase<bool>, DigitalOutput {
      public GpioDigitalOutputImpl(string name, DeviceValue<bool> value) : base(name, DeviceType.DigitalOutput, value) {}
   }
}
