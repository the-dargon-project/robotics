using Dargon.Commons;

namespace Dargon.Robotics.Simulations2D {
   public static class SimulationWheelShaftEncoderStateFactory {
      public static SimulationWheelShaftEncoderState[] FromMotors(SimulationMotorState[] motors, float wheelRadius, int ticksPerRevolution) {
         return Util.Generate(motors.Length, i => FromMotor(motors[i], wheelRadius, ticksPerRevolution));
      }

      public static SimulationWheelShaftEncoderState FromMotor(SimulationMotorState motor, float wheelRadius, int ticksPerRevolution) {
         return new SimulationWheelShaftEncoderState(motor.Name + ".Encoder", motor, wheelRadius, ticksPerRevolution);
      }
   }
}