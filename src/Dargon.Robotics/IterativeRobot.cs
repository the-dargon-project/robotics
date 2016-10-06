using Dargon.Commons;
using System;
using System.Diagnostics;
using System.Threading;

namespace Dargon.Robotics {
   public class IterativeRobot : IRobot {
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
            var timeElapsedMillis = stopwatch.ElapsedMilliseconds;
            var timeToSleepMillis = tickIntervalMillis - timeElapsedMillis;
            if (timeToSleepMillis > 1) {
//               Console.WriteLine($"Finished in {timeElapsedMillis}/{tickIntervalMillis} ms.");
               Thread.Sleep((int)timeToSleepMillis);
            } else if(timeToSleepMillis < 0) {
               Console.Error.WriteLine($"Warning: Iteration took {-timeToSleepMillis} millis too long to execute.");
            }
         }
      }
   }
}
