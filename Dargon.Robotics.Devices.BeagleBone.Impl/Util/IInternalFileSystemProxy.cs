using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices.BeagleBone.Util {
   public interface IInternalFileSystemProxy {
      string ResolveAbsolutePath(string pattern);
      void WriteText(string path, string contents);
   }

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
         File.WriteAllBytes(path, Encoding.ASCII.GetBytes(contents));
      }
   }
}
