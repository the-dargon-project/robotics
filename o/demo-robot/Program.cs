using System.Net;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Devices.Remoting.Server;
using Dargon.Ryu;
using Dargon.Services;
using Dargon.Services.Clustering;

namespace Dargon.Robotics.Demo {
   public class Program {
      public static void Main(string[] args) {
         var ryu = new RyuFactory().Create();

         ryu.Set<ClusteringConfiguration>(
            new ClusteringConfigurationImpl(IPAddress.Loopback, 35135, ClusteringRole.HostOnly));
         ryu.Set<Gamepad>(new NullGamepad());

         ((RyuContainerImpl)ryu).Setup(true);

         var deviceExposer = ryu.Get<DeviceExposer>();
         deviceExposer.ExposeDevices();

         var robot = ryu.Get<Robot>();
         robot.Run();
      }
   }
}
