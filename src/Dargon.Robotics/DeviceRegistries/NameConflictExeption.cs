using System;

namespace Dargon.Robotics.DeviceRegistries {
   public class NameConflictExeption : Exception {
      public NameConflictExeption(string alias, string trueName) : base($"Device of alias already registered: {alias} (True Name: {trueName})") { }
   }
}
