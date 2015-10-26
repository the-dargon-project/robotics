using System;

namespace Dargon.Robotics.Devices.Common {
   public class DeviceAccessDeniedException : Exception {
      private readonly DeviceValueAccess accessGranted;
      private readonly DeviceValueAccess accessRequired;

      public DeviceAccessDeniedException(string path, DeviceValueAccess accessGranted, DeviceValueAccess accessRequired)
         : base(GetMessage(path, accessGranted, accessRequired)) {
         this.accessGranted = accessGranted;
         this.accessRequired = accessRequired;
      }

      public DeviceValueAccess AccessGranted => accessGranted;
      public DeviceValueAccess AccessRequired => accessRequired;

      private static string GetMessage(string path, DeviceValueAccess accessGranted, DeviceValueAccess accessRequired) {
         return $"Operation on {path} required access {accessRequired} but have granted {accessGranted}.";
      }
   }
}