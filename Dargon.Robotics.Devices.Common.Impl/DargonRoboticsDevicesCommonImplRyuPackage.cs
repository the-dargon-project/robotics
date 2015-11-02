using Dargon.Ryu;

namespace Dargon.Robotics.Devices.Common {
   public class DargonRoboticsDevicesCommonImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsDevicesCommonImplRyuPackage() {
         Singleton<DeviceValueFactory, DefaultDeviceValueFactoryImpl>();
      }
   }
}
