namespace Dargon.Robotics.Devices {
   public interface Gamepad {
      float LeftX { get; }
      float LeftY { get; }

      bool A { get; }
      bool B { get; }
      bool X { get; }
      bool Y { get; }

      float RightX { get; }
      float RightY { get; }
   }

   public class NullGamepad : Gamepad {
      public float LeftX => 0.0f;
      public float LeftY => 0.0f;

      public bool A => false;
      public bool B => false;
      public bool X => false;
      public bool Y => false;

      public float RightX => 0.0f;
      public float RightY => 0.0f;
   }
}
