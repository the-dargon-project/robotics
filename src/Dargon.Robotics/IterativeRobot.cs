using Dargon.Commons;
using System;
using System.Diagnostics;
using System.Threading;
using Dargon.Robotics.Debugging;
using Dargon.Ryu.Attributes;

namespace Dargon.Robotics {
   [InjectRequiredFields]
   public class IterativeRobot : IRobot {
      private readonly IterativeRobotConfiguration configuration;
      private readonly IterativeRobotUserCode userCode;
      private readonly IDebugRenderContext debugRenderContext;

      public IterativeRobot(IterativeRobotConfiguration configuration, IterativeRobotUserCode userCode, IDebugRenderContext debugRenderContext) {
         this.configuration = configuration;
         this.userCode = userCode;
         this.debugRenderContext = debugRenderContext;
      }

      public void Run() {
         var stopwatch = new Stopwatch().With(x => x.Start());
         var tickIntervalMillis = 1000 / configuration.IterationsPerSecond;
         userCode.Setup();

         while (true) {
            stopwatch.Restart();
            debugRenderContext.BeginScene();
            userCode.OnTick();
            debugRenderContext.EndScene();
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
