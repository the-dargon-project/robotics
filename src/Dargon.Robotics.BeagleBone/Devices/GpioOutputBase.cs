using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioOutputBase<T> : DeviceBase {
      private readonly IDeviceValue<T> value;

      protected GpioOutputBase(string name, DeviceType type, IDeviceValue<T> value) : base(name, type) {
         this.value = value;
      }

      public void Set(T newValue) => value.Set(newValue);
      public T GetLastValue() => value.Get();
   }
}