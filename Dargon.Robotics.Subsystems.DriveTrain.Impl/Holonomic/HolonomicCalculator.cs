using System;
using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Subsystems.DriveTrains.Holonomic {
   public interface HolonomicCalculator {
      HolonomicDriveValues TankDrive(float left, float right, bool inputsSquared = false);
   }

   public class HolonomicCalculatorImpl : HolonomicCalculator {
      public HolonomicDriveValues TankDrive(float left, float right, bool inputsSquared = false) {
         left = InputUtilities.TransformWithWarning(left, square: inputsSquared);
         right = InputUtilities.TransformWithWarning(right, square: inputsSquared);

         return new HolonomicDriveValues {
            FrontLeft = left,
            FrontRight = right,
            RearLeft = left,
            RearRight = right
         };
      }

      public HolonomicDriveValues MecanumDrive(float x, float y, bool inputsSquared = false) {
         x = InputUtilities.TransformWithWarning(x, square: inputsSquared);
         y = InputUtilities.TransformWithWarning(y, square: inputsSquared);

         throw new NotImplementedException();
      }
   }
}
