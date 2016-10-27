using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D
{
   public class SimulationBallEntity : ISimulationEntity
   {
      private readonly SimulationBallConstants constants;
      private readonly Vector2 centerOfMass;
      private readonly Vector2 initialPosition;
      private Body body;

      public SimulationBallEntity(SimulationBallConstants constants, Vector2 centerOfMass = default(Vector2), Vector2 initialPosition = default(Vector2))
      {
         this.constants = constants;
         this.centerOfMass = centerOfMass;
         this.initialPosition = initialPosition;
      }

      public void Initialize(Simulation2D simulation, World world)
      {
         body = BodyFactory.CreateCircle(world, constants.Radius, constants.Density);
         body.BodyType = BodyType.Dynamic;
         body.Position = initialPosition;
         body.LocalCenter = centerOfMass;
         body.LinearDamping = constants.LinearDamping;
         body.UserData = this;
      }

      public void SetLocalCenter(Vector2 vector) {
         body.LocalCenter = vector;
      }

      public void Render(IRenderer renderer) {
         renderer.DrawCenteredRectangleWorld(
            body.Position,
            new Vector2(constants.Radius, constants.Radius),
            0,
            Color.Green);
      }

      public bool Tick(float dtSeconds) {
         return true;
      }

        public void Delete()
        {
            body.Dispose();
        }
    }

   public class SimulationBallConstants
   {
      public float LinearDamping { get; set; }
      public float Radius { get; set; }
      public float Density { get; set; }
   }

   //   public class SimulationBallState {
   //      private readonly float radius;
   //      private readonly float density;
   //      
   //      public SimulationBallState(float radius, float density) {
   //         this.radius = radius;
   //         this.density = density;
   //      }
   //
   //      public float Radius => radius;
   //      public float Density => density;
   //   }
}
