using System;
using System.Linq;
using Dargon.Robotics.Simulations2D.Util;
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dargon.Robotics.Simulations2D {
   public class Simulation2D : Game, Renderer {
      private const float kTicksPerMillisecond = 10.0f;
      private const float kTickIntervalSeconds = 1.0f / (1000.0f * kTicksPerMillisecond);
      private readonly DateTime startTime = DateTime.Now;
      private readonly SimulationRobotState simulationRobotState;
      private readonly GraphicsDeviceManager graphicsDeviceManager;
      private readonly World world;
      private readonly SimulationRobotEntity robotEntity;
      private int ticksExecuted = 0;
      private SpriteBatch spriteBatch;
      private Texture2D whiteRectangle;

      public Simulation2D(SimulationRobotState simulationRobotState) {
         this.simulationRobotState = simulationRobotState;

         Content.RootDirectory = "Assets";
         ConvertUnits.SetDisplayUnitToSimUnitRatio(50f);

         graphicsDeviceManager = new GraphicsDeviceManager(this) {
            PreferredBackBufferWidth = 1280,
            PreferredBackBufferHeight = 720
         };

         var gravity = Vector2.Zero;
         world = new World(gravity);
         robotEntity = new SimulationRobotEntity(simulationRobotState, world);
         robotEntity.Initialize();
      }

      protected override void LoadContent() {
         base.LoadContent();
         spriteBatch = new SpriteBatch(GraphicsDevice);
         SpriteBatchEx.GraphicsDevice = GraphicsDevice;
         whiteRectangle = CreateSolidBitmap(Color.White);

         Window.Position = Point.Zero;
      }

      protected override void UnloadContent() {
         base.UnloadContent();
         whiteRectangle.Dispose();
         spriteBatch.Dispose();
         graphicsDeviceManager.Dispose();
      }

      protected override void Draw(GameTime gameTime) {
         base.Draw(gameTime);

         GraphicsDevice.Clear(Color.Black);
         spriteBatch.Begin();
         robotEntity.Render(this);
         for (var i = 0; i < 2; i++) {
            DrawLineSegmentWorld(new Vector2(i, 0), new Vector2(i, 40), Color.Gray);
            DrawLineSegmentWorld(new Vector2(0, i), new Vector2(40, i), Color.Gray);
         }
         spriteBatch.End();
      }

      protected override void Update(GameTime gameTime) {
         base.Update(gameTime);
         var millisecondsElapsed = (DateTime.Now - startTime).TotalMilliseconds;
         var desiredTicksExecuted = millisecondsElapsed * kTicksPerMillisecond;
         while (ticksExecuted < desiredTicksExecuted) {
            ticksExecuted++;
            robotEntity.ApplyForces();
            world.Step(kTickIntervalSeconds);
         }
      }

      private Texture2D CreateSolidBitmap(Color color) {
         var texture = new Texture2D(GraphicsDevice, 1, 1);
         texture.SetData(new[] { color });
         return texture;
      }

      public void DrawCenteredRectangleWorld(Vector2 center, Vector2 extents, float rotation, Color color) {
         var centerScreen = ConvertUnits.ToDisplayUnits(center);
         var extentsScreen = ConvertUnits.ToDisplayUnits(extents);

         spriteBatch.Draw(
            whiteRectangle,
            centerScreen,
            null,
            color,
            rotation,
            Vector2.One / 2,
            extentsScreen,
            SpriteEffects.None,
            0);
      }

      public void DrawLineSegmentWorld(Vector2 a, Vector2 b, Color color) {
         var aScreen = ConvertUnits.ToDisplayUnits(a);
         var bScreen = ConvertUnits.ToDisplayUnits(b);
         spriteBatch.DrawLine(aScreen, bScreen, color);
      }
      public void DrawForceVectorWorld(Vector2 origin, Vector2 vector, Color color) {
         const float kScaling = 0.1f;
         var aScreen = ConvertUnits.ToDisplayUnits(origin);
         var bScreen = ConvertUnits.ToDisplayUnits(origin + vector * kScaling);
         spriteBatch.DrawLine(aScreen, bScreen, color);
      }
   }
}