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

      public static void TankMecanumDriveHybrid(this HolonomicDriveTrain driveTrain, float x, float y, float turn, float tankWeight, bool inputsSquared = false) {
         var tank = Calculator.TankDrive(turn, -turn, inputsSquared);
         var mecanum = Calculator.MecanumDrive(driveTrain, x, y, inputsSquared);
         var mecanumWeight = 1.0f - tankWeight;
         var values = new HolonomicDriveValues {
            FrontLeft = tank.FrontLeft * tankWeight + mecanum.FrontLeft * mecanumWeight,
            FrontRight = tank.FrontRight * tankWeight + mecanum.FrontRight * mecanumWeight,
            RearLeft = tank.RearLeft * tankWeight + mecanum.RearLeft * mecanumWeight,
            RearRight = tank.RearRight * tankWeight + mecanum.RearRight * mecanumWeight
         };
         driveTrain.SetValues(values);
      }
   }
}  
