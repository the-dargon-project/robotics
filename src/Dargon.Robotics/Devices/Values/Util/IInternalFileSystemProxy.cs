namespace Dargon.Robotics.Devices.Values.Util {
   public interface IInternalFileSystemProxy {
      string ResolveAbsolutePath(string pattern);
      void WriteText(string path, string contents);
   }
}
