using Microsoft.Xna.Framework;

namespace Dargon.Robotics.Simulations2D {
   public interface IRenderer {
      void DrawCenteredRectangleWorld(Vector2 center, Vector2 extents, float rotation, Color color);
      void DrawLineSegmentWorld(Vector2 a, Vector2 b, Color color);
      void DrawForceVectorWorld(Vector2 origin, Vector2 vector, Color cyan);
   }
}