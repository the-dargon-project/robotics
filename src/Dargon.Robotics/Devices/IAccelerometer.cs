namespace Dargon.Robotics.Devices {
   public interface IAccelerometer : IAnalogInput, IUpdatableDevice {
      float GetPosition();
      float GetVelocity();
      float GetAcceleration();
   }
}