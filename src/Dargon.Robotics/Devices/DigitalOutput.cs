namespace Dargon.Robotics.Devices {
   public interface DigitalOutput : Device {
      void Set(bool value);
      bool GetLastValue();
   }
}