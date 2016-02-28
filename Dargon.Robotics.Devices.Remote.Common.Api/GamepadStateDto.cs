using Dargon.PortableObjects;
using ItzWarty;

namespace Common {
   public class GamepadStateDto : IPortableObject {
      private float leftX;
      private float leftY;
      private float rightX;
      private float rightY;
      private bool[] buttons;

      public GamepadStateDto() { }

      public GamepadStateDto(float leftX, float leftY, float rightX, float rightY, bool[] buttons) {
         this.leftX = leftX;
         this.leftY = leftY;
         this.rightX = rightX;
         this.rightY = rightY;
         this.buttons = buttons;
      }

      public float LeftX => leftX;
      public float LeftY => leftY;
      public float RightX => rightX;
      public float RightY => rightY;
      public bool[] Buttons => buttons;

      public void Serialize(IPofWriter writer) {
         writer.WriteFloat(0, leftX);
         writer.WriteFloat(1, leftY);
         writer.WriteFloat(2, rightX);
         writer.WriteFloat(3, rightY);
         writer.WriteCollection(4, buttons);
      }

      public void Deserialize(IPofReader reader) {
         leftX = reader.ReadFloat(0);
         leftY = reader.ReadFloat(1);
         rightX = reader.ReadFloat(2);
         rightY = reader.ReadFloat(3);
         buttons = reader.ReadArray<bool>(4);
      }

      public override string ToString() => $"{leftX} {leftY} {rightX} {rightY} {buttons.Join(", ")}";
   }
}
