using System;

namespace Dargon.Robotics {
   [Flags]
   public enum SubsystemFlags : uint {
      None     = 0,
      Drive    = 0x00000001U
   }
}
