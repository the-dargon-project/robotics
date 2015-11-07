using System;
using Dargon.Robotics.Codebases.Iterative;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;

namespace Dargon.Robotics.Demo {
   public class DemoRobotIterativeUserCode : IterativeRobotUserCode {
      private readonly Gamepad gamepad;
      private readonly SkidSteerDriveTrain driveTrain;
      private readonly SkidSteerCalculator driveCalculator;

      public DemoRobotIterativeUserCode(Gamepad gamepad, SkidSteerDriveTrain driveTrain, SkidSteerCalculator driveCalculator) {
         this.gamepad = gamepad;
         this.driveTrain = driveTrain;
         this.driveCalculator = driveCalculator;
      }

      public override void OnTick() {
         var driveValues = driveCalculator.TankDrive(gamepad.LeftY, gamepad.RightY);
         driveTrain.SetLeftAndRight(driveValues);
      }
   }
}