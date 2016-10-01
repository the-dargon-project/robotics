using Dargon.PortableObjects;
using ItzWarty;

namespace Dargon.Robotics.Devices.Remote.Common {
   public class GamepadStateDto : IPortableObject {
      private int packetId;
      private float leftX;
      private float leftY;
      private float rightX;
      private float rightY;
      private float leftTrigger;
      private float rightTrigger;
      private bool[] buttons;

      public GamepadStateDto() { }

      public GamepadStateDto(int packetId, float leftX, float leftY, float rightX, float rightY, float leftTrigger, float rightTrigger, bool[] buttons) {
         this.packetId = packetId;
         this.leftX = leftX;
         this.leftY = leftY;
         this.rightX = rightX;
         this.rightY = rightY;
         this.leftTrigger = leftTrigger;
         this.rightTrigger = rightTrigger;
         this.buttons = buttons;
      }

      public int PacketId => packetId;
      public float LeftX => leftX;
      public float LeftY => leftY;
      public float RightX => rightX;
      public float RightY => rightY;
      public float LeftTrigger => leftTrigger;
      public float RightTrigger => rightTrigger;
      public bool[] Buttons => buttons;

      public void Serialize(IPofWriter writer) {
         writer.WriteS32(0, packetId);
         writer.WriteFloat(1, leftX);
         writer.WriteFloat(2, leftY);
         writer.WriteFloat(3, rightX);
         writer.WriteFloat(4, rightY);
         writer.WriteFloat(5, leftTrigger);
         writer.WriteFloat(6, rightTrigger);
         writer.WriteCollection(7, buttons);
      }

      public void Deserialize(IPofReader reader) {
         packetId = reader.ReadS32(0);
         leftX = reader.ReadFloat(1);
         leftY = reader.ReadFloat(2);
         rightX = reader.ReadFloat(3);
         rightY = reader.ReadFloat(4);
         leftTrigger = reader.ReadFloat(5);
         rightTrigger = reader.ReadFloat(6);
         buttons = reader.ReadArray<bool>(7);
      }

      public override string ToString() => $"{packetId}: {leftX} {leftY} {rightX} {rightY} {leftTrigger} {rightTrigger} {buttons.Join(", ")}";
   }
}
