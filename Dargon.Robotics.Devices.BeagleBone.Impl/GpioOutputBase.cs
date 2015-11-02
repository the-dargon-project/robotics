using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioOutputBase<T> : Device {
      private readonly string name;
      private readonly DeviceValue<T> value;

      protected GpioOutputBase(string name, DeviceValue<T> value) {
         this.name = name;
         this.value = value;
      }

      public string Name => name;
      public abstract DeviceType Type { get; }

      public void Set(T newValue) => value.Set(newValue);
      public T GetLastValue() => value.Get();
   }
}