using ItzWarty;
using System.Diagnostics;
using System.Threading;

namespace Dargon.Robotics.Codebases.Iterative {
   public class IterativeRobot : Robot {
      private readonly IterativeRobotConfiguration configuration;
      private readonly IterativeRobotUserCode userCode;

      public IterativeRobot(IterativeRobotConfiguration configuration, IterativeRobotUserCode userCode) {
         this.configuration = configuration;
         this.userCode = userCode;
      }

      public void Run() {
         var stopwatch = new Stopwatch().With(x => x.Start());
         var tickIntervalMillis = 1000 / configuration.IterationsPerSecond;
         userCode.Setup();
         while (true) {
            stopwatch.Restart();
            userCode.OnTick();
            var timeToSleepMillis = stopwatch.ElapsedMilliseconds - tickIntervalMillis;
            if (timeToSleepMillis > 1) {
               Thread.Sleep((int)timeToSleepMillis);
            }
         }
      }
   }
}
