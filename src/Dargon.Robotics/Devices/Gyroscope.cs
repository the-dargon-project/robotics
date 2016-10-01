namespace Dargon.Robotics.Devices {
   public interface Gyroscope : AnalogInput, UpdatableDevice {
      float GetAngle();
      float GetAngularVelocity();
      float GetAngularAcceleration();
   }
}