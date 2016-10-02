namespace Dargon.Robotics.Devices {
   public interface IIncrementalRotaryEncoder : IDevice {
      int Ticks { get; }
      float Rate { get; }

      /// <summary>
      /// In Radians
      /// </summary>
      float Angle { get; }

      /// <summary>
      /// In Radians / Second
      /// </summary>
      float AngularVelocity { get; }
   }

   public interface ILinearEncoder : IDevice {

   }
}
