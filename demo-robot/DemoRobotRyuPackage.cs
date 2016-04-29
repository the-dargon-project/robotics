using Dargon.Robotics.Codebases.Iterative;
using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrains.Vertical;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;
using Dargon.Ryu;

namespace Dargon.Robotics.Demo {
   public class DemoRobotRyuPackage : RyuPackageV1 {
      public DemoRobotRyuPackage() {
         Singleton<Robot, IterativeRobot>();
         Singleton<IterativeRobotConfiguration>(ConstructIterativeRobotConfiguration);
         Singleton<IterativeRobotUserCode, DemoRobotIterativeUserCode>();

         Singleton<Devices>(ConstructDevices);
         Singleton<HolonomicDriveTrain>(ryu => ryu.Get<Devices>().DriveTrain);
         Singleton<Claw>(ryu => ryu.Get<Devices>().Claw);
      }

      private IterativeRobotConfiguration ConstructIterativeRobotConfiguration(RyuContainer ryu) {
         return new IterativeRobotConfiguration(25);
      }

      private Devices ConstructDevices(RyuContainer ryu) {
         var deviceRegistry = ryu.Get<DeviceRegistry>();
         var frontLeftMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.FrontLeft");
         var frontRightMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.FrontRight");
         var rearLeftMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.RearLeft");
         var rearRightMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.RearRight");
 		 var vertFrontLeftMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.VertFrontLeft");
		 var vertFrontRightMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.VertFrontRight");
		 var vertRearMotor = deviceRegistry.GetDevice<Motor>("Drive.Motors.VertRear");
         var driveTrain = new HolonomicDriveTrain(frontLeftMotor, frontRightMotor, rearLeftMotor, rearRightMotor);
		 var vertDriveTrain = new VerticalDriveTrain(vertFrontLeftMotor, vertFrontRightMotor, vertRearMotor);

         var claw = new Claw(
            deviceRegistry.GetDevice<Servo>("Arm.Servos.Wrist"),
            deviceRegistry.GetDevice<Servo>("Arm.Servos.LeftClaw"),
            deviceRegistry.GetDevice<Servo>("Arm.Servos.RightClaw"),
            0, 150,
            0, 100,
            -50, 50);
		return new Devices(driveTrain, vertDriveTrain, claw);
      }
   }
}