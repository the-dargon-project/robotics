using System;
using Common;

namespace Dargon.Robotics.Devices.Remote.Client {
   public class RemoteGamepad : Gamepad {
      public float LeftX { get; private set; }
      public float LeftY { get; private set; }
      public bool A { get; private set; }
      public bool B { get; private set; }
      public bool X { get; private set; }
      public bool Y { get; private set; }
      public float RightX { get; private set; }
      public float RightY { get; private set; }

      public void Update(GamepadStateDto state) {
//         Console.WriteLine("GS: " + state);
         LeftX = state.LeftX;
         LeftY = state.LeftY;
         RightX = state.RightX;
         RightY = state.RightY;
         A = state.Buttons[0];
         B = state.Buttons[1];
         X = state.Buttons[2];
         Y = state.Buttons[3];
      }
   }
}
