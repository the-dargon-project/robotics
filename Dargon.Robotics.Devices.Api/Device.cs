using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public interface Device {
      string Name { get; }
      DeviceType Type { get; }
   }

   public enum DeviceType : uint {
      None = 0,
      AnalogInput = 0x00000001U,
      AnalogOutput = 0x00000002U,
      Encoder = 0x00000004U,
      Motor = 0x00000008U,
      DigitalOutput = 0x00000010U
   }
}
