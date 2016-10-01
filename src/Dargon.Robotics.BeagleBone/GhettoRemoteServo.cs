
using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GhettoRemoteServo : DeviceBase, Servo {
      private readonly DeviceValue<float> position;
      private readonly float defaultAngle;

      public GhettoRemoteServo(string name, DeviceValue<float> position, float defaultAngle) : base (name, DeviceType.Servo) {
         this.position = position;
         this.defaultAngle = defaultAngle;
      }

      public void Initialize() {
         position.Set(defaultAngle);
      }

      public void Set(float value) => position.Set(value);
      public float Get() => position.Get();
   }
}
