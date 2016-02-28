namespace Dargon.Robotics.Devices.Common.Util {
   public interface IInternalFileSystemProxy {
      string ResolveAbsolutePath(string pattern);
      void WriteText(string path, string contents);
   }
}
