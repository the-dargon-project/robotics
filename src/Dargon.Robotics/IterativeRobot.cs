using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Dargon.Commons;
using Dargon.Robotics.Devices;

namespace Dargon.Robotics {
   public class IterativeRobot : Robot {
      private readonly IterativeRobotConfiguration configuration;
      private readonly IterativeRobotUserCode userCode;
      private readonly Gamepad gamepad;

      public IterativeRobot(IterativeRobotConfiguration configuration, IterativeRobotUserCode userCode, Gamepad gamepad) {
         this.configuration = configuration;
         this.userCode = userCode;
         this.gamepad = gamepad;
      }

      public void Run() {
         RunAsync().Wait();
      }

      private async Task RunAsync() {
         var stopwatch = new Stopwatch().With(x => x.Start());
         var tickIntervalMillis = 1000 / configuration.IterationsPerSecond;
         userCode.Setup();

         while (true) {
            stopwatch.Restart();
            userCode.OnTick();
            var timeElapsedMillis = stopwatch.ElapsedMilliseconds;
            var timeToSleepMillis = tickIntervalMillis - timeElapsedMillis;
            if (timeToSleepMillis > 1) {
               Console.WriteLine($"Finished in {timeElapsedMillis}/{tickIntervalMillis} ms.");
               Thread.Sleep((int)timeToSleepMillis);
            } else if(timeToSleepMillis < 0) {
               Console.Error.WriteLine($"Warning: Iteration took {-timeToSleepMillis} millis too long to execute.");
            }
         }
      }
   }
}
