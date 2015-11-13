using Dargon.Robotics.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameGamePad = Microsoft.Xna.Framework.Input.GamePad;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class LocalGamepad : Gamepad {
      public float LeftX => GetState().ThumbSticks.Left.X;
      public float LeftY => -GetState().ThumbSticks.Left.Y;
      public bool LeftTrigger => GetState().Triggers.Left > 0;
      public float RightX => GetState().ThumbSticks.Right.X;
      public float RightY => -GetState().ThumbSticks.Right.Y;

      private GamePadState GetState() => MonogameGamePad.GetState(PlayerIndex.One);
   }
}
