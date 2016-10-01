namespace Dargon.Robotics.Devices {
   public interface IAnalogOutput : IDevice {
      void Set(float value);
      float GetLastValue();
   }
}