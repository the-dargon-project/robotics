using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationMotorState {
      public SimulationMotorState(string name, Vector2 relativePosition, Vector2 maxForceVector) {
         this.Name = name;
         this.RelativePosition = relativePosition;
         this.MaxForceVector = maxForceVector;
         this.CurrentForceVector = Vector2.Zero;
      }

      public string Name { get; }
      public Vector2 RelativePosition { get; }
      public Vector2 MaxForceVector { get; }
      public Vector2 CurrentForceVector { get; set; }
   }
}