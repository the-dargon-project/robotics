using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.DriveTrain.SkidSteer {
   public class DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage : RyuModule {
      public DargonRoboticsSubsystemsDriveTrainsImplSkidSteerRyuPackage() {
         Required.Singleton<SkidSteerCalculatorImpl>().Implements<ISkidSteerCalculator>();
      }
   }
}
