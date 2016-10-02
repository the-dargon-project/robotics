namespace Dargon.Robotics.Devices {
   public interface IGyroscope : IUpdatableDevice {
      float GetAngle();
      float GetAngularVelocity();
      float GetAngularAcceleration();
   }
}