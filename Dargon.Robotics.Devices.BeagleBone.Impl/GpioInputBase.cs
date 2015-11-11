using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Devices.BeagleBone {
   public abstract class GpioInputBase<T> : DeviceBase {
      private readonly DeviceValue<T> value;

      protected GpioInputBase(string name, DeviceType type, DeviceValue<T> value) : base(name, type) {
         this.value = value;
      }

      public T Get() => value.Get();
   }
}
