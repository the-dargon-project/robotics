using System;
using ItzWarty;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Devices.Remote.Client;

namespace Dargon.Robotics.Codebases.Iterative {
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

         var remoteGamepad = gamepad as RemoteGamepad;
         while (true) {
            if (remoteGamepad != null) {
               await remoteGamepad.WaitUpdateAsync();
            }
            stopwatch.Restart();
            userCode.OnTick();
            var timeElapsedMillis = stopwatch.ElapsedMilliseconds;
            var timeToSleepMillis = tickIntervalMillis - timeElapsedMillis;
            if (timeToSleepMillis > 1) {
               if (remoteGamepad == null) {
                  Thread.Sleep((int)timeToSleepMillis);
               }
               Console.WriteLine($"Finished in {timeElapsedMillis}/{tickIntervalMillis} ms.");
            } else if(timeToSleepMillis < 0) {
               Console.Error.WriteLine($"Warning: Iteration took {-timeToSleepMillis} millis too long to execute.");
            }
         }
      }
   }
}
