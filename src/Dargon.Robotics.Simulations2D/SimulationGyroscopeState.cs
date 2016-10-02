namespace Dargon.Robotics.Simulations2D {
   public class SimulationGyroscopeState {
      public SimulationGyroscopeState(string name) {
         Name = name;
      }

      public string Name { get; set; }

      // In Radians
      public float Angle { get; set; }
      
      // In Radians
      public float AngularVelocity { get; set; }
   }
}
