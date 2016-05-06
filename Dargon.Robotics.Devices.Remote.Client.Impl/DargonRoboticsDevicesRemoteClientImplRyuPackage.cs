using Dargon.Courier;
using Dargon.Robotics.Devices.Remote.Common;
using Dargon.Ryu;
using System;

namespace Dargon.Robotics.Devices.Remote.Client {
   public class DargonRoboticsDevicesRemoteClientImplRyuPackage : RyuPackageV1 {
      public DargonRoboticsDevicesRemoteClientImplRyuPackage() {
         Singleton<Gamepad>(ConstructGamepad);
      }

      private Gamepad ConstructGamepad(RyuContainer ryu) {
         var gamepad = new RemoteGamepad();
         const int kPort = 21337;
         var courierClientFactory = ryu.Get<CourierClientFactory>();
         var courierClient = courierClientFactory.CreateUdpCourierClient(kPort,
            new CourierClientConfiguration {
               Identifier = Guid.NewGuid()
            });
         ryu.Set(courierClient);
         courierClient.RegisterPayloadHandler<GamepadStateDto>(x => gamepad.Update(x.Payload));
         Console.WriteLine("Constructed courier client");
         return gamepad;
      }
   }
}
