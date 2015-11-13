using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Subsystems.DriveTrains.Holonomic {
   public class HolonomicDriveTrain {
      private readonly Motor frontLeft;
      private readonly Motor frontRight;
      private readonly Motor rearLeft;
      private readonly Motor rearRight;

      public HolonomicDriveTrain(Motor frontLeft, Motor frontRight, Motor rearLeft, Motor rearRight) {
         this.frontLeft = frontLeft;
         this.frontRight = frontRight;
         this.rearLeft = rearLeft;
         this.rearRight = rearRight;
      }

      public Motor FrontLeft => frontLeft;
      public Motor FrontRight => frontRight;
      public Motor RearLeft => rearLeft;
      public Motor RearRight => rearRight;

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
