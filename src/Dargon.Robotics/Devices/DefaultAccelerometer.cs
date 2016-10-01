using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices {
   public class DefaultAccelerometer : DeviceBase, IAccelerometer {
      private readonly IAnalogInput acceleration;
      private readonly IAccumulator velocity;
      private readonly IAccumulator position;

      public DefaultAccelerometer(string name, IAnalogInput acceleration, IAccumulator velocity, IAccumulator position) : base(name, DeviceType.Accelerometer) {
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
