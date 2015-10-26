using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;

namespace Dargon.Robotics.Demo {
   public class Devices {
      public Devices(SkidSteerDriveTrain driveTrain) {
         DriveTrain = driveTrain;
      }

      public SkidSteerDriveTrain DriveTrain { get; }
   }
}