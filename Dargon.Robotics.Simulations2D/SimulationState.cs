namespace Dargon.Robotics.Simulations2D {
   public class SimulationState {
      private readonly SimulationRobotState robotState;

      public SimulationState(SimulationRobotState robotState) {
         this.robotState = robotState;
      }

      public SimulationRobotState RobotState => robotState;
   }
}