using System;

namespace Dargon.Robotics.Devices.Values {
   public class DeviceAccessDeniedException : Exception {
      private readonly DeviceValueAccess accessGranted;
      private readonly DeviceValueAccess accessRequired;

      public DeviceAccessDeniedException(DeviceValueAccess accessGranted, DeviceValueAccess accessRequired)
         : base(GetMessage(accessGranted, accessRequired)) {
         this.accessGranted = accessGranted;
         this.accessRequired = accessRequired;
      }

      public DeviceValueAccess AccessGranted => accessGranted;
      public DeviceValueAccess AccessRequired => accessRequired;

      private static string GetMessage(DeviceValueAccess accessGranted, DeviceValueAccess accessRequired) {
         return $"Operation required access {accessRequired} but have granted {accessGranted}.";
      }
   }
}