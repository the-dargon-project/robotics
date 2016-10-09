namespace Dargon.Robotics.Devices.DriveTrain.Holonomic {
   public class HolonomicDriveTrain {
      private readonly IMotor frontLeft;
      private readonly IMotor frontRight;
      private readonly IMotor rearLeft;
      private readonly IMotor rearRight;

      public HolonomicDriveTrain(IMotor frontLeft, IMotor frontRight, IMotor rearLeft, IMotor rearRight) {
         this.frontLeft = frontLeft;
         this.frontRight = frontRight;
         this.rearLeft = rearLeft;
         this.rearRight = rearRight;
      }

      public IMotor FrontLeft => frontLeft;
      public IMotor FrontRight => frontRight;
      public IMotor RearLeft => rearLeft;
      public IMotor RearRight => rearRight;

      public void SetValues(HolonomicDriveValues values) {
         SetValues(values.FrontLeft, values.FrontRight, values.RearLeft, values.RearRight);
      }

      public void SetValues(float frontLeftSpeed, float frontRightSpeed, float rearLeftSpeed, float rearRightSpeed) {
         frontLeft.Set(frontLeftSpeed);
         frontRight.Set(frontRightSpeed);

         rearLeft.Set(rearLeftSpeed);
         rearRight.Set(rearRightSpeed);
      }
   }
}
