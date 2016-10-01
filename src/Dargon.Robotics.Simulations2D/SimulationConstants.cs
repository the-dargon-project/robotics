namespace Dargon.Robotics.Simulations2D {
   public class SimulationConstants {
      public float LinearDamping { get; set; }
      public float AngularDamping { get; set; }
      public float Width { get; set; }
      public float Height { get; set; }
      public float Density { get; set; }
   }

   public static class SimulationConstantsFactory {
      private const float kAluminumDensity = 2700; // kg/m3

      public static SimulationConstants LandRobot() {
         return new SimulationConstants {
            AngularDamping = 3.75f,
            LinearDamping = 2.0f,
            Width = 0.66f,
            Height = 0.66f,
            Density = kAluminumDensity * 0.0125f // brings us to ~64 pounds
         };
      }

      public static SimulationConstants WaterRobot() {
         return new SimulationConstants {
            AngularDamping = 30.0f,
            LinearDamping = 1.0f,
            Width = 0.66f,
            Height = 0.66f,
            Density = kAluminumDensity * 0.0475f // brings us to ~100 pounds
         };
      }
   }
}