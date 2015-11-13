namespace Dargon.Robotics.Devices.Components {
   public class VectorComponent {
      public VectorComponent() { }

      public VectorComponent(float x, float y, float z) {
         this.X = x;
         this.Y = y;
         this.Z = z;
      }

      public float X { get; set; }
      public float Y { get; set; }
      public float Z { get; set; }
   }
}
