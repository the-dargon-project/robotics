using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Robotics;
using Dargon.Robotics.Devices;
using Dargon.Ryu;

namespace demo_robot_beaglebone {
   class Program {
      static void Main(string[] args) {
         var ryu = new RyuFactory().Create();
         ryu.Set<Gamepad>(new NullGamepad());
         ((RyuContainerImpl)ryu).Setup(true);

         var actualRobot = ryu.Get<Robot>();
         actualRobot.Run();
      }
   }
}
