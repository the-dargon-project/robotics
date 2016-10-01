namespace Dargon.Robotics.Codebases.Iterative {
   public class IterativeRobotConfiguration {
      public IterativeRobotConfiguration(int iterationsPerSecond) {
         IterationsPerSecond = iterationsPerSecond;
      }

      public int IterationsPerSecond { get; }
   }

   public abstract class IterativeRobotUserCode {
      public virtual void Setup() { }
      public virtual void OnTick() { }
   }
}