using System;
using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Subsystems.DriveTrains.SkidSteer {
   public class SkidSteerDriveTrain {
      private readonly Motor frontLeft;
      private readonly Motor frontRight;
      private readonly Motor rearLeft;
      private readonly Motor rearRight;

      public SkidSteerDriveTrain(Motor frontLeft, Motor frontRight) {
         this.frontLeft = frontLeft;
         this.frontRight = frontRight;
      }

      public SkidSteerDriveTrain(Motor frontLeft, Motor frontRight, Motor rearLeft, Motor rearRight) {
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
