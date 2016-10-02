using System.Collections.Generic;
using System.Drawing;
using MathNet.Spatial.Euclidean;

namespace Dargon.Robotics.DebugScene {
   public interface IDebugRenderContext {
      DebugScene CurrentScene { get; set; }
      DebugScene NextScene { get; set; }
      void BeginScene();
      void AddQuad(DebugSceneQuad quad);
      void EndScene();
   }

   public class DebugRenderContext : IDebugRenderContext {
      public DebugScene CurrentScene { get; set; } = new DebugScene();
      public DebugScene NextScene { get; set; } = new DebugScene();

      public void BeginScene() {
         NextScene = new DebugScene();
      }

      public void AddQuad(DebugSceneQuad quad) => NextScene.Quads.Add(quad);

      public void EndScene() {
         CurrentScene = NextScene;
         NextScene = null;
      }
   }

   public class DebugScene {
      public List<DebugSceneQuad> Quads { get; } = new List<DebugSceneQuad>();
   }

   public struct DebugSceneQuad {
      public Vector2D Position { get; set; }
      public Vector2D Extents { get; set; }
      public float Rotation { get; set; }
      public Color Color { get; set; }
   }
}
