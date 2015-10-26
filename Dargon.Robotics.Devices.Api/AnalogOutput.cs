namespace Dargon.Robotics.Devices {
   public interface AnalogOutput : Device {
      void Set(float value);
      float GetLastValue();
   }
}