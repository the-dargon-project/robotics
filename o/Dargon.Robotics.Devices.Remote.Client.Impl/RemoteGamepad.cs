using System.Threading.Tasks;
using Dargon.Robotics.Devices.Remote.Common;
using Nito.AsyncEx;

namespace Dargon.Robotics.Devices.Remote.Client {
   public class RemoteGamepad : Gamepad {
      private readonly object synchronization = new object();
      private readonly AsyncAutoResetEvent updatedSignal = new AsyncAutoResetEvent();
      private int lastPacketId = -1;

      public float LeftX { get; private set; }
      public float LeftY { get; private set; }

      public float LeftTrigger { get; private set; }
      public float RightTrigger { get; private set; }

      public float RightX { get; private set; }
      public float RightY { get; private set; }

      public bool A { get; private set; }
      public bool B { get; private set; }
      public bool X { get; private set; }
      public bool Y { get; private set; }

      public bool LeftShoulder { get; private set; }
      public bool RightShoulder { get; private set; }
      public bool Back { get; private set; }
      public bool Start { get; private set; }

      public bool DpadLeft { get; private set; }
      public bool DpadRight { get; private set; }
      public bool DpadUp { get; private set; }
      public bool DpadDown { get; private set; }

      public async Task WaitUpdateAsync() {
         await updatedSignal.WaitAsync();
      }

      public void Update(GamepadStateDto state) {
         lock (synchronization) {
            if (state.PacketId < lastPacketId) {
               return;
            }
            lastPacketId = state.PacketId;
         }

         LeftX = state.LeftX;
         LeftY = state.LeftY;

         RightX = state.RightX;
         RightY = state.RightY;

         LeftTrigger = state.LeftTrigger;
         RightTrigger = state.RightTrigger;

         A = state.Buttons[0];
         B = state.Buttons[1];
         X = state.Buttons[2];
         Y = state.Buttons[3];

         LeftShoulder = state.Buttons[4];
         RightShoulder = state.Buttons[5];
         Back = state.Buttons[6];
         Start = state.Buttons[7];

         DpadLeft = state.Buttons[8];
         DpadRight = state.Buttons[9];
         DpadUp = state.Buttons[10];
         DpadDown = state.Buttons[11];

         updatedSignal.Set();
      }
   }
}
