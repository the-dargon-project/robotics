using Dargon.Robotics.Devices.Values.Util;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.Values {
   public class DargonRoboticsDevicesCommonImplRyuPackage : RyuModule {
      public DargonRoboticsDevicesCommonImplRyuPackage() {
         Required.Singleton<DefaultDeviceValueFactoryImpl>().Implements<DeviceValueFactory>();
         Required.Singleton<InternalFileSystemProxy>().Implements<IInternalFileSystemProxy>();
      }
   }
}
