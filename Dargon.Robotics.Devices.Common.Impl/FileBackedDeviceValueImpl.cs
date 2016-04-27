using System.IO;
using Dargon.Robotics.Devices.Common.Util;

namespace Dargon.Robotics.Devices.Common {
   public class FileBackedDeviceValueImpl<T> : DeviceValue<T> {
      private readonly string path;
      private readonly DeviceValueAccess access;
      private readonly IInternalFileSystemProxy internalFileSystemProxy;

      public FileBackedDeviceValueImpl(string path, DeviceValueAccess access, IInternalFileSystemProxy internalFileSystemProxy) {
         this.path = path;
         this.access = access;
         this.internalFileSystemProxy = internalFileSystemProxy;
      }

      public T Get() => ValueSerializer<T>.Deserialize(File.ReadAllText(path), access);
      public void Set(T value) => internalFileSystemProxy.WriteText(path, ValueSerializer<T>.Serialize(value, access));

      public override string ToString() => $"{path} ${access}";
   }
}