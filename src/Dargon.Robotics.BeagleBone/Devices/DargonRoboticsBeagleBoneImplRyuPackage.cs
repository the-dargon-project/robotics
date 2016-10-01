using Dargon.Robotics.DeviceRegistries;
using Dargon.Ryu;
using Dargon.Ryu.Modules;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class DargonRoboticsBeagleBoneImplRyuPackage : RyuModule {
      public DargonRoboticsBeagleBoneImplRyuPackage() {
         Optional.Singleton<BeagleBoneGpioConfigurationManagerImpl>()
                 .Implements<IBeagleBoneGpioConfigurationManager>();
         Optional.Singleton<BeagleBoneGpioConfigurationManagerImpl>();
         Optional.Singleton<BeagleBoneGpioMotorDeviceFactoryImpl>()
                 .Implements<IBeagleBoneGpioMotorDeviceFactory>();
         Optional.Singleton<BeagleBoneDeviceFactory>()
                 .Implements<IDeviceFactory>();
         Optional.Singleton<BeagleBoneDeviceFactory>();
         Optional.Singleton<IDeviceRegistry>(ConstructAndPopulateDeviceRegistry);
         Optional.Singleton<DeviceConfigurationLoaderImpl>();
      }

      public IDeviceRegistry ConstructAndPopulateDeviceRegistry(IRyuContainer ryu) {
         var deviceRegistry = new DefaultDeviceRegistry();
         var deviceConfigurationLoader = ryu.GetOrThrow<DeviceConfigurationLoaderImpl>();
         deviceConfigurationLoader.LoadDeviceConfiguration(deviceRegistry);
         return deviceRegistry;
      }
   }
}
