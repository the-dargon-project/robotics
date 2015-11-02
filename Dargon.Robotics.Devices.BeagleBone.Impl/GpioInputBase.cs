using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioInputBase<T> : Device {
      private readonly string name;
      private readonly DeviceValue<T> value;

      protected GpioInputBase(string name, DeviceValue<T> value) {
         this.name = name;
         this.value = value;
      }

      public string Name => name;
      public abstract DeviceType Type { get; }

      public T Get() => value.Get();
   }
}
