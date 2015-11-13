using Dargon.Robotics.Devices;
using Microsoft.Xna.Framework.Input;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class KeyboardGamepad : Gamepad {
      public float LeftX => GetValue(Keys.A, Keys.D);
      public float LeftY => GetValue(Keys.S, Keys.W);
      public bool LeftTrigger => GetBoolean(Keys.LeftShift);

      public float RightX => GetValue(Keys.K, Keys.OemSemicolon);
      public float RightY => GetValue(Keys.L, Keys.O);

      public float GetValue(Keys negative, Keys positive) {
         var state = Keyboard.GetState();
         if (state.IsKeyDown(negative)) {
            return -1;
         } else if (state.IsKeyDown(positive)) {
            return 1;
         } else {
            return 0;
         }
      }

      private bool GetBoolean(Keys key) {
         var state = Keyboard.GetState();
         return state.IsKeyDown(key);
      }
   }
}
