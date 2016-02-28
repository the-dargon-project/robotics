using Dargon.Ryu;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DargonRoboticsBeagleBoneImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsBeagleBoneImplRyuPackage() {
         Singleton<IBeagleBoneGpioConfigurationManager, BeagleBoneGpioConfigurationManagerImpl>();
         Singleton<BeagleBoneGpioConfigurationManagerImpl>();
         Singleton<IBeagleBoneGpioMotorDeviceFactory, BeagleBoneGpioMotorDeviceFactoryImpl>();
         Singleton<DeviceFactory, BeagleBoneDeviceFactory>();
         Singleton<BeagleBoneDeviceFactory>();
         Singleton<DeviceRegistry>(ConstructAndPopulateDeviceRegistry);
         Singleton<DeviceConfigurationLoaderImpl>();
      }

      public DeviceRegistry ConstructAndPopulateDeviceRegistry(RyuContainer ryu) {
         var deviceRegistry = new DefaultDeviceRegistry();
         var deviceConfigurationLoader = ryu.Get<DeviceConfigurationLoaderImpl>();
         deviceConfigurationLoader.LoadDeviceConfiguration(deviceRegistry);
         return deviceRegistry;
      }
   }
}
