using Dargon.Robotics.Devices.Values;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioInputBase<T> : DeviceBase {
      private readonly IDeviceValue<T> value;

      protected GpioInputBase(string name, DeviceType type, IDeviceValue<T> value) : base(name, type) {
         this.value = value;
      }

      public T Get() => value.Get();
   }
}
