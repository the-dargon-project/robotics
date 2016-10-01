using System;
using NLog;

namespace Dargon.Robotics.Devices.Values.Util {
   public static class InputUtilities {
      private static readonly Logger logger = LogManager.GetCurrentClassLogger();

      public static float TransformWithWarning(float value, float min = -1.0f, float max = 1.0f, bool square = false) {
         value = ClampWithWarning(value);
         if (square) {
            value = value * Math.Abs(value);
         }
         return value;
      }

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
