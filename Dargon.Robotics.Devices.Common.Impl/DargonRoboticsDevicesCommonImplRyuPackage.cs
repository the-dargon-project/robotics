using Dargon.Robotics.Devices.Common.Util;
using Dargon.Ryu;

namespace Dargon.Robotics.Devices.Common {
   public class DargonRoboticsDevicesCommonImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsDevicesCommonImplRyuPackage() {
         Singleton<DeviceValueFactory, DefaultDeviceValueFactoryImpl>();

         Singleton<IInternalFileSystemProxy, InternalFileSystemProxy>();
         Singleton<InternalFileSystemProxy>();
      }
   }
}
