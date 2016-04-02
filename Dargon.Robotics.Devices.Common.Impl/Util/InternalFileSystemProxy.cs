using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Dargon.Robotics.Devices.Common.Util {
   public class InternalFileSystemProxy : IInternalFileSystemProxy {
      public string ResolveAbsolutePath(string pattern) {
         var parts = pattern.Split('/');
         Trace.Assert(parts[0] == "");
         var currentDirectory = new DirectoryInfo("/");
         for (var i = 1; i < parts.Length - 1; i++) {
            currentDirectory = currentDirectory.GetDirectories(parts[i]).First();
         }
         return currentDirectory.GetFiles(parts.Last()).First().FullName;
      }

      public void WriteText(string path, string contents) {
         Console.WriteLine("Write to " + path + " " + contents);
         var buffer = Encoding.ASCII.GetBytes(contents);
         if (Environment.OSVersion.Platform != PlatformID.Unix) {
            File.WriteAllBytes(path, buffer);
         } else {
            using (var fs = File.Open(path, FileMode.Truncate, FileAccess.Write, FileShare.None)) {
               fs.Write(buffer, 0, buffer.Length);
               fs.Flush();
            }
         }
      }
   }
}