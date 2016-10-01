namespace Dargon.Robotics.Subsystems.DriveTrain.SkidSteer {
   public struct SkidDriveValues {
      public static readonly SkidDriveValues kZero = new SkidDriveValues(0.0f, 0.0f);

      public SkidDriveValues(float left, float right) {
         Left = left;
         Right = right;
      }

      public float Left { get; }
      public float Right { get; }
   }
}