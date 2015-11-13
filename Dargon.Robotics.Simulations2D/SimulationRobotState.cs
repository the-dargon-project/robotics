using System.Collections.Generic;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationRobotState {
      private readonly float width;
      private readonly float height;
      private readonly float density;
      private readonly SimulationMotorState[] motorStates;
      private readonly SimulationWheelEncoderState[] wheelEncoderStates;

      public SimulationRobotState(float width, float height, float density, SimulationMotorState[] motorStates, SimulationWheelEncoderState[] wheelEncoderStates) {
         this.width = width;
         this.height = height;
         this.density = density;
         this.motorStates = motorStates;
         this.wheelEncoderStates = wheelEncoderStates;
      }

      public float Width => width;
      public float Height => height;
      public float Density => density;
      public IReadOnlyList<SimulationMotorState> MotorStates => motorStates;
      public IReadOnlyList<SimulationWheelEncoderState> WheelEncoderStates => wheelEncoderStates;
   }
}