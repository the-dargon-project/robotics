using Dargon.Robotics.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonogameGamePad = Microsoft.Xna.Framework.Input.GamePad;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class LocalGamepad : Gamepad {
      public float LeftX => GetState().ThumbSticks.Left.X;
      public float LeftY => -GetState().ThumbSticks.Left.Y;

      public float RightX => GetState().ThumbSticks.Right.X;
      public float RightY => -GetState().ThumbSticks.Right.Y;

      public float LeftTrigger => GetState().Triggers.Left;
      public float RightTrigger => GetState().Triggers.Right;

      public bool A => GetState().IsButtonDown(Buttons.A);
      public bool B => GetState().IsButtonDown(Buttons.B);
      public bool X => GetState().IsButtonDown(Buttons.X);
      public bool Y => GetState().IsButtonDown(Buttons.Y);
      public bool LeftShoulder => GetState().IsButtonDown(Buttons.LeftShoulder);
      public bool RightShoulder => GetState().IsButtonDown(Buttons.RightShoulder);
      public bool Back => GetState().IsButtonDown(Buttons.Back);
      public bool Start => GetState().IsButtonDown(Buttons.Start);
      public bool DpadLeft => GetState().DPad.Left == ButtonState.Pressed;
      public bool DpadRight => GetState().DPad.Right == ButtonState.Pressed;
      public bool DpadUp => GetState().DPad.Up == ButtonState.Pressed;
      public bool DpadDown => GetState().DPad.Down == ButtonState.Pressed;

      private GamePadState GetState() => MonogameGamePad.GetState(PlayerIndex.One);
   }
}
