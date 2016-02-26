using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Robotics.Devices.BeagleBone.Util;
using ItzWarty;

namespace Dargon.Robotics.Devices.BeagleBone {
   public interface IBeagleBoneGpioConfigurationManager {
      void SetPinMode(string pinName, PinMode mode);
   }

   public class BeagleBoneGpioConfigurationManagerImpl : IBeagleBoneGpioConfigurationManager {
      private readonly IInternalFileSystemProxy internalFileSystemProxy;
      private bool initialized = false;

      public BeagleBoneGpioConfigurationManagerImpl(IInternalFileSystemProxy internalFileSystemProxy) {
         this.internalFileSystemProxy = internalFileSystemProxy;
      }

      public void Initialize() {
         if (initialized) return;
         initialized = true;

         // ReSharper disable once StringLiteralTypo
         const string kCapeManagerSlotsPath = "/sys/devices/bone_capemgr.*/slots";
         var capeManagerPath = internalFileSystemProxy.ResolveAbsolutePath(kCapeManagerSlotsPath);

         const string kExportAllPins = "cape-universaln";
         internalFileSystemProxy.WriteText(capeManagerPath, kExportAllPins);
      }

      public void SetPinMode(string pinName, PinMode mode) {
         const string kPinStatePath = "/sys/devices/ocp.*/{0}_pinmux.*/state";
         string pinStatePath = internalFileSystemProxy.ResolveAbsolutePath(kPinStatePath.F(pinName));
         var state = mode.GetAttributeOrNull<DescriptionAttribute>().Description;
         internalFileSystemProxy.WriteText(pinStatePath, state);
      }
   }

   public enum PinMode {
      [Description("gpio")]
      Gpio,

      [Description("pwm")]
      Pwm
   }
}
