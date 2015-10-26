using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public class GpioInputBase : Device {
      private readonly string name;
      private readonly DeviceValue<float> voltage;

      public GpioInputBase(string name, DeviceValue<float> voltage) {
         this.name = name;
         this.voltage = voltage;
      }

      public string Name => name;

      public float Get() => voltage.Get();
   }
}
