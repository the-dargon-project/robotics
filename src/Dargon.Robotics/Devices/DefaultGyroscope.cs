namespace Dargon.Robotics.Devices {
   public class DefaultGyroscope : DeviceBase, Accelerometer {
      private readonly AnalogInput angularAcceleration;
      private readonly Accumulator angularVelocity;
      private readonly Accumulator angularPosition;

      public DefaultGyroscope(string name, AnalogInput angularAcceleration, Accumulator angularVelocity, Accumulator angularPosition) : base(name, DeviceType.Gyroscope) {
         this.angularAcceleration = angularAcceleration;
         this.angularVelocity = angularVelocity;
         this.angularPosition = angularPosition;
      }

      public void Update() {
         angularVelocity.Update();
         angularPosition.Update();
      }

      public float Get() => GetPosition();
      public float GetPosition() => angularPosition.Get();
      public float GetVelocity() => angularVelocity.Get();
      public float GetAcceleration() => angularAcceleration.Get();
   }
}