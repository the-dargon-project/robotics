namespace Dargon.Robotics.Devices {
   public class DefaultGyroscope : DeviceBase, IAccelerometer {
      private readonly IAnalogInput angularAcceleration;
      private readonly IAccumulator angularVelocity;
      private readonly IAccumulator angularPosition;

      public DefaultGyroscope(string name, IAnalogInput angularAcceleration, IAccumulator angularVelocity, IAccumulator angularPosition) : base(name, DeviceType.Gyroscope) {
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