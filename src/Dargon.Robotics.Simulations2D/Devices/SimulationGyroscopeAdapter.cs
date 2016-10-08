using Dargon.Robotics.Devices;
using System;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class SimulationGyroscopeAdapter : DeviceBase, IGyroscope {
      private readonly SimulationGyroscopeState state;
      private float lastAngularVelocity;
      private DateTime lastUpdateTime;
      private float computedAngularAcceleration;

      public SimulationGyroscopeAdapter(SimulationGyroscopeState state) : base(state.Name, DeviceType.Gyroscope) {
         this.state = state;

         lastAngularVelocity = state.AngularVelocity;
         lastUpdateTime = DateTime.Now;
      }

      public void Update() {
         var now = DateTime.Now;
         if (lastUpdateTime != now) {
            var angularVelocity = state.AngularVelocity;
            computedAngularAcceleration = (float)((angularVelocity - lastAngularVelocity) / (now - lastUpdateTime).TotalSeconds);
            lastAngularVelocity = angularVelocity;
            lastUpdateTime = now;
         }
      }

      public float GetAngle() {
         return state.Angle;
      }

      public float GetAngularVelocity() {
         return state.AngularVelocity;
      }

      public float GetAngularAcceleration() {
         return computedAngularAcceleration;
      }
   }
}
