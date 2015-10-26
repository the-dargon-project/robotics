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
         var leftMotor = deviceRegistry.GetDevice<Motor>("drive_left_motor");
         var rightMotor = deviceRegistry.GetDevice<Motor>("drive_right_motor");
         var driveTrain = new SkidSteerDriveTrain(leftMotor, rightMotor);
         return new Devices(driveTrain);
      }
   }
}