using System;
using System.CodeDom;

namespace Dargon.Robotics.Devices {
   public interface Servo : Device {
      void Set(float value);
      float Get();
   }

   public class NullServo : Servo {
      public NullServo(string name = null) {
         Name = name ?? "NULL_SERVO";
      }

      public string Name { get; set; }

      public DeviceType Type => DeviceType.Servo;

      public TComponent GetComponent<TComponent>(DeviceComponentType type) {
         throw new InvalidOperationException();
      }

      public void Set(float value) { }
      public float Get() => 0;
   }
}
