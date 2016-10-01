namespace Dargon.Robotics.Devices {
   public interface Encoder : Device {
      int Count { get; }
      float Rate { get; }
   }
}
