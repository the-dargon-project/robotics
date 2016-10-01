using Dargon.Ryu;

namespace Dargon.Robotics.Subsystems.DriveTrains.SkidSteer {
   public class DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage : RyuPackageV1 {
      public DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage() {
         Singleton<SkidSteerCalculator, SkidSteerCalculatorImpl>();
      }
   }
}
