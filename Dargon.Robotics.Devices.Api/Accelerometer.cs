namespace Dargon.Robotics.Devices {
   public interface Accelerometer : AnalogInput, UpdatableDevice {
      float GetPosition();
      float GetVelocity();
      float GetAcceleration();
   }
}