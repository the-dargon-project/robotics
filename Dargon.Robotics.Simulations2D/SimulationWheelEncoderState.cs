using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationWheelEncoderState {
      public SimulationWheelEncoderState(string name, SimulationMotorState motor) {
         Name = name;
         Motor = motor;
      }

      public string Name { get; }
      public SimulationMotorState Motor { get; }
      public bool HasBeenUpdated { get; set; } = false;
      public Vector2 LastWorldPosition { get; set; }
      public double Position { get; set; }
      public double Velocity { get; set; }
   }
}