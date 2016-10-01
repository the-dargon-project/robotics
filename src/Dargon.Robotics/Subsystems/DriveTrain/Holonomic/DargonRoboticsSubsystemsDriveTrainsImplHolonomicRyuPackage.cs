using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;
using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Subsystems.DriveTrains.Holonomic {
   public class DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage : RyuModule {
      public DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage() {
         Required.Singleton<HolonomicCalculator>(ConstructAndConfigureHolonomicCalculator);
      }

      private HolonomicCalculator ConstructAndConfigureHolonomicCalculator(IRyuContainer ryu) {
         var calculator = new HolonomicCalculatorImpl();
         HolonomicDriveTrainStatics.Calculator = calculator;
         return calculator;
      }
   }
}
