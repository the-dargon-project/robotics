using Dargon.Robotics.Codebases.Iterative;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;
using Dargon.Ryu;

namespace Dargon.Robotics.Demo {
   public class DemoRobotRyuPackage : RyuPackageV1 {
      public DemoRobotRyuPackage() {
         Singleton<Robot, IterativeRobot>();
         Singleton<IterativeRobotConfiguration>(ConstructIterativeRobotConfiguration);
         Singleton<IterativeRobotUserCode, DemoRobotIterativeUserCode>();

         Singleton<Devices>(ConstructDevices);
         Singleton<SkidSteerDriveTrain>(ryu => ryu.Get<Devices>().DriveTrain);
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
         var driveTrain = new SkidSteerDriveTrain(frontLeftMotor, frontRightMotor, rearLeftMotor, rearRightMotor);
         return new Devices(driveTrain);
      }
   }
}