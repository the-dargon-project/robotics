using ItzWarty;
using System;

namespace Dargon.Robotics.Devices.Common {
   public static class ValueSerializer<T> {
      public static T Deserialize(string s, DeviceValueAccess access) {
         if ((access & DeviceValueAccess.Read) == 0) {
            throw new DeviceAccessDeniedException(access, DeviceValueAccess.Read);
         } else if (typeof(T) == typeof(string)) {
            return (T)(object)s;
         } else if (typeof(T) == typeof(int)) {
            return (T)(object)int.Parse(s);
         } else if (typeof(T) == typeof(float)) {
            return (T)(object)float.Parse(s);
         } else if (typeof(T) == typeof(bool)) {
            return (T)(object)s.ContainsAny(new[] { "1", "true" }, StringComparison.OrdinalIgnoreCase);
         } else {
            throw new InvalidOperationException($"Attempted to deserialize unhandled type: {typeof(T)}");
         }
      }

      public static string Serialize(T value, DeviceValueAccess access) {
         if ((access & DeviceValueAccess.Write) == 0) {
            throw new DeviceAccessDeniedException(access, DeviceValueAccess.Write);
         } else if (typeof(T) == typeof(string) || typeof(T) == typeof(int) || typeof(T) == typeof(float)) {
            return value.ToString();
         } else if (typeof(T) == typeof(bool)) {
            return (bool)(object)value ? "1" : "0";
         } else {
            throw new InvalidOperationException($"Attempted to serialize unhandled type: {typeof(T)}");
         }
      }

   }
}