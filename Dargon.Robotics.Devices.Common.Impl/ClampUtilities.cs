using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Dargon.Robotics.Devices.Common {
   public static class ClampUtilities {
      private static readonly Logger logger = LogManager.GetCurrentClassLogger();

      public static float ClampWithWarning(float value, float min = -1.0f, float max = 1.0f) {
         if (value < min) {
            Warn($"{value} < {min}");
            value = min;
         } else if (value > max) {
            Warn($"{value} > {max}");
            value = max;
         }
         return value;
      }

      private static void Warn(string message) {
         logger.Warn(message + Environment.StackTrace);
      }
   }
}
