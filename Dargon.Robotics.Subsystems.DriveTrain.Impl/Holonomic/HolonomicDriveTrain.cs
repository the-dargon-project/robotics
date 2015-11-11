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

      public void SetValues(float frontLeftSpeed, float frontRightSpeed, float rearLeftSpeed, float rearRightSpeed) {
         frontLeft.Set(frontLeftSpeed);
         frontRight.Set(frontLeftSpeed);

         rearLeft.Set(rearLeftSpeed);
         rearRight.Set(rearRightSpeed);
      }
   }
}
