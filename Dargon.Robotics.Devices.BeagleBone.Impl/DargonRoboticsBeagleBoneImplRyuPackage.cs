using Dargon.Ryu;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DargonRoboticsBeagleBoneImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsBeagleBoneImplRyuPackage() {
         Singleton<DeviceFactory, BeagleBoneDeviceFactory>();
      }
   }
}
