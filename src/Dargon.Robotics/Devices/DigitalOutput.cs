namespace Dargon.Robotics.Devices {
   public interface DigitalOutput : IDevice {
      void Set(bool value);
      bool GetLastValue();
   }
}