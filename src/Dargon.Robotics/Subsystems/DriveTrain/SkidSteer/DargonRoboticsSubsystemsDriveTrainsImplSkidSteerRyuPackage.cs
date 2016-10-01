using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Subsystems.DriveTrains.SkidSteer {
   public class DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage : RyuModule {
      public DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage() {
         Required.Singleton<SkidSteerCalculatorImpl>().Implements<SkidSteerCalculator>();
      }
   }
}
