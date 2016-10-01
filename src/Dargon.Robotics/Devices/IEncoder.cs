namespace Dargon.Robotics.Devices {
   public interface IEncoder : IDevice {
      int Count { get; }
      float Rate { get; }
   }
}
