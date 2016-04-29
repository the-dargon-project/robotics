using Dargon.Robotics.Codebases.Iterative;
using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrains.Vertical;


namespace Dargon.Robotics.Demo {
   public class DemoRobotIterativeUserCode : IterativeRobotUserCode {
      private readonly Gamepad gamepad;
      private readonly HolonomicDriveTrain driveTrain;
	  private readonly VerticalDriveTrain vertDriveTrain;
      private readonly Claw claw;

      public DemoRobotIterativeUserCode(Gamepad gamepad, HolonomicDriveTrain driveTrain, VerticalDriveTrain vertDriveTrain, Claw claw) {
         this.gamepad = gamepad;
         this.driveTrain = driveTrain;
		 this.vertDriveTrain = vertDriveTrain;
         this.claw = claw;
      }

      public override void OnTick() {
         driveTrain.MecanumDrive(gamepad.LeftX, gamepad.LeftY);
		 vertDriveTrain.SetValues(gamepad.RightY,gamepad.RightY,gamepad.RightY)

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