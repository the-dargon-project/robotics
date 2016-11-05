using System.Collections.Generic;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationRobotState {
      private readonly float width;
      private readonly float height;
      private readonly float density;
      private readonly float linearDamping;
      private readonly float angularDamping;
      private readonly SimulationMotorState[] motorStates;
      private readonly SimulationWheelShaftEncoderState[] wheelShaftEncoderStates;
      private readonly SimulationGyroscopeState yawGyroscopeState;

      public SimulationRobotState(float width, float height, float density, float linearDamping, float angularDamping, SimulationMotorState[] motorStates, SimulationWheelShaftEncoderState[] wheelShaftEncoderStates, SimulationGyroscopeState yawGyroscopeState) {
         this.width = width;
         this.height = height;
         this.density = density;
         this.linearDamping = linearDamping;
         this.angularDamping = angularDamping;
         this.motorStates = motorStates;
         this.wheelShaftEncoderStates = wheelShaftEncoderStates;
         this.yawGyroscopeState = yawGyroscopeState;
      }

      public float Width => width;
      public float Height => height;
      public float Density => density;
      public float LinearDamping => linearDamping;
      public float AngularDamping => angularDamping;
      public IReadOnlyList<SimulationMotorState> MotorStates => motorStates;
      public IReadOnlyList<SimulationWheelShaftEncoderState> WheelShaftEncoderStates => wheelShaftEncoderStates;
      public SimulationGyroscopeState YawGyroscopeState => yawGyroscopeState;
   }
}