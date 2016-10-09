using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.DriveTrain.Holonomic {
   public class DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage : RyuModule {
      public DargonRoboticsSubsystemsDriveTrainsImplHolonomicRyuPackage() {
         Required.Singleton<IHolonomicCalculator>(ConstructAndConfigureHolonomicCalculator);
      }

      private IHolonomicCalculator ConstructAndConfigureHolonomicCalculator(IRyuContainer ryu) {
         var calculator = new HolonomicCalculatorImpl();
         HolonomicDriveTrainStatics.Calculator = calculator;
         return calculator;
      }
   }
}
