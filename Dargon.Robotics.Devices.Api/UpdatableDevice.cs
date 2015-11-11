﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public interface UpdatableDevice : Device {
      void Update();
   }
}
