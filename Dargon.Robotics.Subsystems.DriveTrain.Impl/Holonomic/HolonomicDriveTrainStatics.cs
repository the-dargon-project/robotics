using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Subsystems.DriveTrains.Holonomic {
   public static class HolonomicDriveTrainStatics {
      public static HolonomicCalculator Calculator { get; set; } = new HolonomicCalculatorImpl();

      public static void TankDrive(this HolonomicDriveTrain driveTrain, float left, float right, bool inputsSquared = false) {
         var values = Calculator.TankDrive(left, right, inputsSquared);
         driveTrain.SetValues(values);
      }

      public static void MecanumDrive(this HolonomicDriveTrain driveTrain, float x, float y, bool inputsSquared = false) {
         var values = Calculator.MecanumDrive(driveTrain, x, y, inputsSquared);
         driveTrain.SetValues(values);
      }
   }
}
