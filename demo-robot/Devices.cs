using Dargon.Robotics.Demo.Subsystems;
using Dargon.Robotics.Subsystems.DriveTrains.Holonomic;
using Dargon.Robotics.Subsystems.DriveTrains.Vertical;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;

namespace Dargon.Robotics.Demo {
   public class Devices {
		public Devices(HolonomicDriveTrain driveTrain, VerticalDriveTrain vertDriveTrain, Claw claw) {
         DriveTrain = driveTrain;
		 VertDriveTrain = vertDriveTrain;
         Claw = claw;
      }

      public HolonomicDriveTrain DriveTrain { get; }
	  public VerticalDriveTrain VertDriveTrain { get; }
      public Claw Claw { get; }
   }
}