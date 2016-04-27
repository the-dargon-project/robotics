namespace Dargon.Robotics.Devices {
   public interface Servo : Device {
      void Set(float value);
      float Get();
   }
}
