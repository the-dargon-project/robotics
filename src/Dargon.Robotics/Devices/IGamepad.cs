using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public interface IGamepad {
      float LeftX { get; }
      float LeftY { get; }

      float RightX { get; }
      float RightY { get; }

      float LeftTrigger { get; }
      float RightTrigger { get; }

      bool A { get; }
      bool B { get; }
      bool X { get; }
      bool Y { get; }

      bool LeftShoulder { get; }
      bool RightShoulder { get; }
      bool Back { get; }
      bool Start { get; }

      bool DpadLeft { get; }
      bool DpadRight { get; }
      bool DpadUp { get; }
      bool DpadDown { get; }
   }

   public class NullGamepad : IGamepad {
      public float LeftX => 0.0f;
      public float LeftY => 0.0f;

      public float RightX => 0.0f;
      public float RightY => 0.0f;

      public float LeftTrigger => 0.0f;
      public float RightTrigger => 0.0f;

      public bool A => false;
      public bool B => false;
      public bool X => false;
      public bool Y => false;

      public bool LeftShoulder => false;
      public bool RightShoulder => false;
      public bool Back => false;
      public bool Start => false;

      public bool DpadLeft => false;
      public bool DpadRight => false;
      public bool DpadUp => false;
      public bool DpadDown => false;
   }
}
