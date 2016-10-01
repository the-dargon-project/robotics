namespace Dargon.Robotics.Devices {
   public interface Motor : Device {
      void Set(float value);
      float GetLastValue();
   }
}