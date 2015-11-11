using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public class DefaultAccelerometer : DeviceBase, Accelerometer {
      private readonly AnalogInput acceleration;
      private readonly Accumulator velocity;
      private readonly Accumulator position;

      public DefaultAccelerometer(string name, AnalogInput acceleration, Accumulator velocity, Accumulator position) : base(name, DeviceType.Accelerometer) {
         this.acceleration = acceleration;
         this.velocity = velocity;
         this.position = position;
      }

      public void Update() {
         velocity.Update();
         position.Update();
      }

      public float Get() => GetPosition();
      public float GetPosition() => position.Get();
      public float GetVelocity() => velocity.Get();
      public float GetAcceleration() => acceleration.Get();
   }
}
