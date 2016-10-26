using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public interface ISimulationEntity {
      void Initialize(World world);
      void SetLocalCenter(Vector2 vector);
      void Render(IRenderer renderer);
      bool Tick(float dtSeconds);
   }
}