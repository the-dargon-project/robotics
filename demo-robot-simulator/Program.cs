using System;
using System.Threading;
using Dargon.Robotics; 
using Dargon.Robotics.Devices;
using Dargon.Robotics.Simulations2D;
using Dargon.Robotics.Simulations2D.Devices;
using Dargon.Ryu;

namespace demo_robot_simulator {
   public class Program {
      private const float kMecanumWheelForceAngle = (float)(Math.PI / 4);
      private const float kMecanumWheelForceMagnitude = 50 * 1000.0f;
      private const float kNewtonMetersPerOzInch = 0.00706155183333f;
      private const float kMotorTorque = 2.42f; //50 * kNewtonMetersPerOzInch;
      private const float kMetersPerInch = 0.0254f;
      private const float kWheelRadius = 2 * kMetersPerInch;
      private const float kWheelForce = kMotorTorque / kWheelRadius;

      public static void Main(string[] args) {
         // create simulation state
         var constants = SimulationConstantsFactory.WaterRobot();
//         var motors = SimulationMotorStateFactory.MecanumDrive(constants.Width, constants.Height, kMecanumWheelForceAngle, kWheelForce);
         var motors = SimulationMotorStateFactory.RovDrive(constants.Width, constants.Height, kMecanumWheelForceAngle, kWheelForce);
         var wheelEncoders = SimulationWheelEncoderStateFactory.FromMotors(motors);
         var robot = new SimulationRobotState(constants.Width, constants.Height, constants.Density, motors, wheelEncoders);
         var robotEntity = new SimulationRobotEntity(constants, robot);

         // create robot state
         var deviceRegistry = new DefaultDeviceRegistry();
         foreach (var simulationMotorState in robot.MotorStates) {
            var motor = new SimulationMotorAdapter(simulationMotorState);
            deviceRegistry.AddDevice(motor);
            motor.Set(0.1f);
         }

         // start robot code in new thread
         new Thread(() => {
            var ryu = new RyuFactory().Create();
            ryu.Set<Gamepad>(new KeyboardGamepad());
            ryu.Set<DeviceRegistry>(deviceRegistry);
            ((RyuContainerImpl)ryu).Setup(true);

            var actualRobot = ryu.Get<Robot>();
            actualRobot.Run();
         }).Start();

         new Simulation2D(robotEntity).Run();
      }
   }
}
