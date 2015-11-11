using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioOutputBase<T> : DeviceBase {
      private readonly DeviceValue<T> value;

      protected GpioOutputBase(string name, DeviceType type, DeviceValue<T> value) : base(name, type) {
         this.value = value;
      }

      public void Set(T newValue) => value.Set(newValue);
      public T GetLastValue() => value.Get();
   }
}