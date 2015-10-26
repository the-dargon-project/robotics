using System.CodeDom;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Dargon.Robotics.Devices.Common {
   public interface DeviceValue<T> {
      T Get();
      void Set(T value);
   }
}
