using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public class SimulationWheelShaftEncoderState {
      public SimulationWheelShaftEncoderState(string name, SimulationMotorState motor, float wheelRadius, int ticksPerRevolution) {
         Name = name;
         Motor = motor;
         WheelRadius = wheelRadius;
         TicksPerRevolution = ticksPerRevolution;
      }

      public string Name { get; }
      public SimulationMotorState Motor { get; }
      public float WheelRadius { get; }
      public int TicksPerRevolution { get; }
      public bool HasBeenUpdated { get; set; } = false;
      public Vector2 LastWorldPosition { get; set; }

      /// <summary>
      /// In Radians
      /// </summary>
      public double Angle { get; set; }

      /// <summary>
      /// In Radians
      /// </summary>
      public double AngularVelocity { get; set; }
   }
}