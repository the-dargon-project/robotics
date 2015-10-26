namespace Dargon.Robotics.Devices {
   public interface Gamepad {
      float LeftX { get; }
      float LeftY { get; }

      float RightX { get; }
      float RightY { get; }
   }

   public class NullGamepad : Gamepad {
      public float LeftX => 0.0f;
      public float LeftY => 0.0f;

      public float RightX => 0.0f;
      public float RightY => 0.0f;
   }
}
