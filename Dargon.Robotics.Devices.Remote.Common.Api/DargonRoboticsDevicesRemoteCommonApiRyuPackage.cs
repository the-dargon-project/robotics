using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.PortableObjects;
using Dargon.Ryu;

namespace Dargon.Robotics.Devices.Remote.Common {
   public class DargonRoboticsDevicesRemoteCommonApiRyuPackage : RyuPackageV1 {
      public DargonRoboticsDevicesRemoteCommonApiRyuPackage() {
         PofContext<DargonRoboticsDevicesRemoteCommonApiPofContext>();
      }
   }

   public class DargonRoboticsDevicesRemoteCommonApiPofContext : PofContext {
      private const int kBasePofId = 4000000;
      public DargonRoboticsDevicesRemoteCommonApiPofContext() {
         RegisterPortableObjectType(kBasePofId + 0, typeof(GamepadStateDto));
      }
   }
}
