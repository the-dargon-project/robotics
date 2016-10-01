using Dargon.Robotics.Devices.Common.Util;
using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.Common {
   public class DargonRoboticsDevicesCommonImplRyuPackage : RyuModule {
      public DargonRoboticsDevicesCommonImplRyuPackage() {
         Required.Singleton<DefaultDeviceValueFactoryImpl>().Implements<DeviceValueFactory>();
         Required.Singleton<InternalFileSystemProxy>().Implements<IInternalFileSystemProxy>();
      }
   }
}
