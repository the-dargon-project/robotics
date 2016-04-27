using Dargon.Robotics.Codebases.Iterative;
using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;

namespace Dargon.Robotics.Demo {
   public class DemoRobotIterativeUserCode : IterativeRobotUserCode {
      private readonly Gamepad gamepad;
      private readonly HolonomicDriveTrain driveTrain;
      private readonly Claw claw;

      public DemoRobotIterativeUserCode(Gamepad gamepad, HolonomicDriveTrain driveTrain, Claw claw) {
         this.gamepad = gamepad;
         this.driveTrain = driveTrain;
         this.claw = claw;
      }

      public override void OnTick() {
         driveTrain.MecanumDrive(gamepad.LeftX, gamepad.LeftY);

         if (gamepad.A) {
            claw.SetGripDegrees(20);
         } else if (gamepad.B) {
            claw.SetGripDegrees(70);
         }

         if (gamepad.X) {
            claw.SetDirectionalDegrees(-40);
         } else if (gamepad.Y) {
            claw.SetDirectionalDegrees(40);
         } else {
            claw.SetDirectionalDegrees(0);
         }
      }
   }
}