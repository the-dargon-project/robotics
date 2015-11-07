using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Robotics.Subsystems.DriveTrains.SkidSteer;
using Dargon.Ryu;

namespace Dargon.Robotics.Subsystems.DriveTrains {
   public class DargonRoboticsSubsystemsDriveTrainsImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsSubsystemsDriveTrainsImplRyuPackage() {
         Singleton<SkidSteerCalculator, SkidSteerCalculatorImpl>();
      }
   }
}
