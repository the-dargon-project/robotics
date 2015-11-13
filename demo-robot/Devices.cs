using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;

namespace Dargon.Robotics.Demo {
   public class Devices {
      public Devices(HolonomicDriveTrain driveTrain) {
         DriveTrain = driveTrain;
      }

      public HolonomicDriveTrain DriveTrain { get; }
   }
}