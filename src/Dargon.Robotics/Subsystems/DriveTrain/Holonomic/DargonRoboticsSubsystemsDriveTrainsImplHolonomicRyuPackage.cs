using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;
using Dargon.Ryu;

namespace Dargon.Robotics.Subsystems.DriveTrains.Holonomic {
   public class DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage : RyuPackageV1 {
      public DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage() {
         Singleton<HolonomicCalculator>(ConstructAndConfigureHolonomicCalculator);
      }

      private HolonomicCalculator ConstructAndConfigureHolonomicCalculator(RyuContainer ryu) {
         var calculator = new HolonomicCalculatorImpl();
         HolonomicDriveTrainStatics.Calculator = calculator;
         return calculator;
      }
   }
}
