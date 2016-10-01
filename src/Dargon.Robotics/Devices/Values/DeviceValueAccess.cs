using System;

namespace Dargon.Robotics.Devices.Values {
   [Flags]
   public enum DeviceValueAccess {
      None = 0,
      Read = 1,
      Write = 2,
      ReadWrite = Read | Write
   }
}