using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioOutputBase {
      private readonly string name;
      private readonly DeviceValue<float> voltage;

      public GpioOutputBase(string name, DeviceValue<float> voltage) {
         this.name = name;
         this.voltage = voltage;
      }

      public string Name => name;

      public void Set(float value) => voltage.Set(value);
      public float GetLastValue() => voltage.Get();
   }
}