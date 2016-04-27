using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;

namespace Dargon.Robotics.Demo {
   public class Devices {
      public Devices(HolonomicDriveTrain driveTrain, Claw claw) {
         DriveTrain = driveTrain;
         Claw = claw;
      }

      public HolonomicDriveTrain DriveTrain { get; }
      public Claw Claw { get; }
   }
}