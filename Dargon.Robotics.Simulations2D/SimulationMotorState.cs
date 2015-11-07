using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationMotorState {
      public SimulationMotorState(Vector2 relativePosition, Vector2 maxForceVector) {
         this.RelativePosition = relativePosition;
         this.MaxForceVector = maxForceVector;
         this.CurrentForceVector = Vector2.Zero;
      }

      public Vector2 RelativePosition { get; set; }
      public Vector2 MaxForceVector { get; set; }
      public Vector2 CurrentForceVector { get; set; }
   }
}