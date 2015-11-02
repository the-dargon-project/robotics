using System;
using System.IO;
using ItzWarty;

namespace Dargon.Robotics.Devices.Common {
   public class FileBackedDeviceValueImpl<T> : DeviceValue<T> {
      private readonly string path;
      private readonly DeviceValueAccess access;
      private readonly Func<T> read;
      private readonly Action<T> write;

      public FileBackedDeviceValueImpl(string path, DeviceValueAccess access) {
         this.path = path;
         this.access = access;
         this.read = GetReader(path, access);
         this.write = GetWriter(path, access);
      }

      public T Get() => read();
      public void Set(T value) => write(value);

      public static Func<T> GetReader(string path, DeviceValueAccess access) {
         if (!access.HasFlag(DeviceValueAccess.Read)) {
            return () => { throw new DeviceAccessDeniedException(path, access, DeviceValueAccess.Read); };
         } else if (typeof(T) == typeof(string)) {
            return () => (T)(object)File.ReadAllText(path);
         } else if (typeof(T) == typeof(int)) {
            return () => (T)(object)int.Parse(File.ReadAllText(path));
         } else if (typeof(T) == typeof(float)) {
            return () => (T)(object)float.Parse(File.ReadAllText(path));
         } else if (typeof(T) == typeof(bool)) {
            return () => (T)(object)File.ReadAllText(path).ContainsAny(
               new[] { "1", "true" }, StringComparison.OrdinalIgnoreCase);
         } else {
            throw new InvalidOperationException($"Attempted to get reader of unhandled type: {typeof(T)}");
         }
      }

      public static Action<T> GetWriter(string path, DeviceValueAccess access) {
         if (!access.HasFlag(DeviceValueAccess.Write)) {
            return v => { throw new DeviceAccessDeniedException(path, access, DeviceValueAccess.Write); };
         } else if (typeof(T) == typeof(string) ||
                    typeof(T) == typeof(int) ||
                    typeof(T) == typeof(float)) {
            return v => File.WriteAllText(path, v.ToString());
         } else if (typeof(T) == typeof(bool)) {
            return v => File.WriteAllText(path, ((bool)(object)v) ? "1" : "0");
         } else {
            throw new InvalidOperationException($"Attempted to get writer of unhandled type: {typeof(T)}");
         }
      }

      public override string ToString() => $"{path} ${access}";
   }
}