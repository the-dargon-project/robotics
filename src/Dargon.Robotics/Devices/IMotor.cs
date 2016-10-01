namespace Dargon.Robotics.Devices {
   public interface IMotor : IDevice {
      void Set(float value);
      float GetLastValue();
   }
}