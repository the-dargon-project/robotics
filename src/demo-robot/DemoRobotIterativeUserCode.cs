using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrain.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrain.Vertical;


namespace Dargon.Robotics.Demo {
   public class DemoRobotIterativeUserCode : IterativeRobotUserCode {
      private readonly IGamepad gamepad;
      private readonly HolonomicDriveTrain driveTrain;
      private readonly VerticalDriveTrain vertDriveTrain;
      private readonly Claw claw;
      private readonly IServo armElbowServo;

      public DemoRobotIterativeUserCode(IGamepad gamepad, HolonomicDriveTrain driveTrain, VerticalDriveTrain vertDriveTrain, Claw claw) {
         this.gamepad = gamepad;
         this.driveTrain = driveTrain;
         this.vertDriveTrain = vertDriveTrain;
         this.claw = claw;
         this.armElbowServo = claw.ElbowServo;;
      }

      public override void OnTick() {
         if (gamepad.RightShoulder) {
            driveTrain.TankDrive(gamepad.LeftY, gamepad.RightY);
            vertDriveTrain.SetValues(0, 0, 0);
         } else if (gamepad.LeftShoulder) {
            driveTrain.MecanumDrive(gamepad.LeftX, gamepad.LeftY);
            vertDriveTrain.SetValues(gamepad.RightY, gamepad.RightY, gamepad.RightY);
         } else {
            driveTrain.TankMecanumDriveHybrid(
               gamepad.LeftX,
               gamepad.LeftY,
               gamepad.RightX,
               0.2f);
            if (gamepad.LeftTrigger > 0.5) {
               vertDriveTrain.SetValues(-0.8f, -0.8f, 0.9f);
            } else if (gamepad.RightTrigger > 0.5) {
               vertDriveTrain.SetValues(gamepad.RightY, gamepad.RightY, gamepad.RightY);
            } else {
               vertDriveTrain.SetValues(0, 0, 0);
            }
         }

         if (gamepad.Start) {
            claw.Reset();
         }

//         if (gamepad.Y) {
//            armElbowServo.Set(50000);
//         } else if (gamepad.A) {
//            armElbowServo.Set(1);
//         } else {
//            armElbowServo.Set(0);
//         }

         if (gamepad.DpadUp) {
            claw.SetGripDegrees(claw.GetGripDegrees() + 3);
         } else if (gamepad.DpadDown) {
            claw.SetGripDegrees(claw.GetGripDegrees() - 3);
         }

         if (gamepad.DpadLeft) {
            claw.SetDirectionalDegrees(claw.GetDirectionalDegrees() + 3);
         } else if (gamepad.DpadRight) {
            claw.SetDirectionalDegrees(claw.GetDirectionalDegrees() - 3);
         }


//         if (gamepad.X) {
//            claw.SetWristDegrees(claw.GetWristDegrees() - 3);
//         } else if (gamepad.B) {
//            claw.SetWristDegrees(claw.GetWristDegrees() + 3);
//         }
      }
   }
}