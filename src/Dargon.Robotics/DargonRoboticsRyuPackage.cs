using Dargon.Robotics.Devices.Values.Util;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.Values {
   public class DargonRoboticsRyuPackage : RyuModule {
      public DargonRoboticsRyuPackage() {
         Required.Singleton<DefaultDeviceValueFactoryImpl>().Implements<IDeviceValueFactory>();
         Required.Singleton<InternalFileSystemProxy>().Implements<IInternalFileSystemProxy>();
      }
   }
}
