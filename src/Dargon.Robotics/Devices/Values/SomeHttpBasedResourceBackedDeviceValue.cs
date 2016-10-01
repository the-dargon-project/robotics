using System.Net;

namespace Dargon.Robotics.Devices.Values {
   public class SomeHttpBasedResourceBackedDeviceValue<T> : IDeviceValue<T> {
      private readonly WebClient webClient;
      private readonly string getResourceTemplate;
      private readonly string setResourceTemplate;
      private readonly DeviceValueAccess access;

      public SomeHttpBasedResourceBackedDeviceValue(WebClient webClient, string getResourceTemplate, string setResourceTemplate, DeviceValueAccess access) {
         this.webClient = webClient;
         this.getResourceTemplate = getResourceTemplate;
         this.setResourceTemplate = setResourceTemplate;
         this.access = access;
      }

      public T Get() {
         if ((access & DeviceValueAccess.Write) == 0) {
            throw new DeviceAccessDeniedException(access, DeviceValueAccess.Write);
         }

         var response = webClient.DownloadString(getResourceTemplate);
         return ValueSerializer<T>.Deserialize(response, access);
      }

      public void Set(T value) {
         var url = string.Format(setResourceTemplate, ValueSerializer<T>.Serialize(value, access));
         webClient.DownloadString(url);
      }
   }
}