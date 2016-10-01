using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.DeviceRegistries;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Subsystems.DriveTrain.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrain.Vertical;
using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Demo {
   public class DemoRobotRyuPackage : RyuModule {
      public DemoRobotRyuPackage() {
         Optional.Singleton<IterativeRobot>().Implements<IRobot>();
         Optional.Singleton<IterativeRobotConfiguration>(ConstructIterativeRobotConfiguration);
         Optional.Singleton<DemoRobotIterativeUserCode>().Implements<IterativeRobotUserCode>();

         Optional.Singleton<Devices>(ConstructDevices);
         Optional.Singleton<HolonomicDriveTrain>(ryu => ryu.GetOrActivate<Devices>().DriveTrain);
         Optional.Singleton<VerticalDriveTrain>(ryu => ryu.GetOrActivate<Devices>().VerticalDriveTrain);
         Optional.Singleton<Claw>(ryu => ryu.GetOrActivate<Devices>().Claw);
      }

      private IterativeRobotConfiguration ConstructIterativeRobotConfiguration(IRyuContainer ryu) {
         return new IterativeRobotConfiguration(100);
      }

      private Devices ConstructDevices(IRyuContainer ryu) {
         var deviceRegistry = ryu.GetOrActivate<IDeviceRegistry>();
         var frontLeftMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.FrontLeft");
         var frontRightMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.FrontRight");
         var rearLeftMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.RearLeft");
         var rearRightMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.RearRight");
         var vertFrontLeftMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.VertFrontLeft");
         var vertFrontRightMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.VertFrontRight");
         var vertRearMotor = deviceRegistry.GetDevice<IMotor>("Drive.Motors.VertRear");
         var driveTrain = new HolonomicDriveTrain(frontLeftMotor, frontRightMotor, rearLeftMotor, rearRightMotor);
         var vertDriveTrain = new VerticalDriveTrain(vertFrontLeftMotor, vertFrontRightMotor, vertRearMotor);

         var claw = new Claw(
            deviceRegistry.GetDevice<IServo>("Arm.Servos.Wrist"),
            deviceRegistry.GetDevice<IServo>("Arm.Servos.LeftClaw"),
            deviceRegistry.GetDevice<IServo>("Arm.Servos.RightClaw"),
            deviceRegistry.GetDevice<IServo>("Arm.Servos.Elbow"),
            -90, 90,
            0, 100,
            -50, 50);
         return new Devices(driveTrain, vertDriveTrain, claw);
      }
   }
}