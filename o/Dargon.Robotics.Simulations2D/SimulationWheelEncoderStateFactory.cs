using ItzWarty;

namespace Dargon.Robotics.Simulations2D {
   public static class SimulationWheelEncoderStateFactory {
      public static SimulationWheelEncoderState[] FromMotors(SimulationMotorState[] motors) {
         return Util.Generate(motors.Length, i => FromMotor(motors[i]));
      }

      public static SimulationWheelEncoderState FromMotor(SimulationMotorState motor) {
         return new SimulationWheelEncoderState(motor.Name + ".Encoder", motor);
      }
   }
}