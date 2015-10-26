using Dargon.Ryu;

namespace Dargon.Robotics.Demo {
   public class Program {
      public static void Main(string[] args) {
         var ryu = new RyuFactory().Create();
         ((RyuContainerImpl)ryu).Setup(true);

         var robot = ryu.Get<Robot>();
         robot.Run();
      }
   }
}
