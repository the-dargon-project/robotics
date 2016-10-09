namespace Dargon.Robotics.Devices.DriveTrain.SkidSteer {
   public class SkidSteerDriveTrain {
      private readonly IMotor frontLeft;
      private readonly IMotor frontRight;
      private readonly IMotor rearLeft;
      private readonly IMotor rearRight;

      public SkidSteerDriveTrain(IMotor frontLeft, IMotor frontRight) {
         this.frontLeft = frontLeft;
         this.frontRight = frontRight;
      }

      public SkidSteerDriveTrain(IMotor frontLeft, IMotor frontRight, IMotor rearLeft, IMotor rearRight) {
         this.frontLeft = frontLeft;
         this.frontRight = frontRight;
         this.rearLeft = rearLeft;
         this.rearRight = rearRight;
      }

      public void SetLeftAndRight(SkidDriveValues values) {
         SetLeftAndRight(values.Left, values.Right);
      }

      public void SetLeftAndRight(float left, float right) {
         frontLeft.Set(left);
         frontRight.Set(right);

         rearLeft?.Set(left);
         rearRight?.Set(right);
      }
   }
}
