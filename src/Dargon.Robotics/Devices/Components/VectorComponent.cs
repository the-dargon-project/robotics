namespace Dargon.Robotics.Devices.Components {
   public class VectorComponent {
      public VectorComponent() { }

      public VectorComponent(float x, float y, float z) {
         X = x;
         Y = y;
         Z = z;
      }

      public float X { get; set; }
      public float Y { get; set; }
      public float Z { get; set; }
   }
}
