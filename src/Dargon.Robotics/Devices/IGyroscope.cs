namespace Dargon.Robotics.Devices {
   public interface IGyroscope : IAnalogInput, IUpdatableDevice {
      float GetAngle();
      float GetAngularVelocity();
      float GetAngularAcceleration();
   }
}