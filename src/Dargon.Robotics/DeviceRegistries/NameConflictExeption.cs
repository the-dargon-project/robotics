using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public class NameConflictExeption : Exception {
      public NameConflictExeption(string alias, string trueName) : base($"Device of alias already registered: {alias} (True Name: {trueName})") { }
   }
}
