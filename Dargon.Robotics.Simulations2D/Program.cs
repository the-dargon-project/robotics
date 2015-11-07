using System;

namespace Dargon.Robotics.Simulations2D {
   public class Program {
      private const float kAluminumDensity = 2700; // kg/m3
      private const float kRobotDensity = kAluminumDensity * 0.0125f; // brings us to 64lb
      private const float kRobotWidth = 0.66f;
      private const float kRobotHeight = 0.66f;
      private const float kMecanumWheelForceAngle = (float)(Math.PI / 4);
      private const float kMecanumWheelForceMagnitude = 50 * 1000.0f;
      private const float kNewtonMetersPerOzInch = 0.00706155183333f;
      private const float kMotorTorque = 2.42f; //50 * kNewtonMetersPerOzInch;
      private const float kMetersPerInch = 0.0254f;
      private const float kWheelRadius = 2 * kMetersPerInch;
      private const float kWheelForce = kMotorTorque / kWheelRadius;

      public static void Main(string[] args) {
//         Console.WriteLine(kMotorTorque + " " +  kWheelForce);
//         return; 
         var motors = SimulationMotorStateFactory.MecanumDrive(kRobotWidth, kRobotHeight, kMecanumWheelForceAngle, kWheelForce);
//         var motors = SimulationMotorStateFactory.SkidDrive(kRobotWidth, kRobotHeight, kWheelForce);
         var robot = new SimulationRobotState(kRobotWidth, kRobotHeight, kRobotDensity, motors);

         new Simulation2D(robot).Run();
      }
   }
}
