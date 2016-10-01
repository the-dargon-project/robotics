namespace Dargon.Robotics.Devices.Values.Util {
   public class MultiplyShiftDeviceValueImpl : DeviceValue<float> {
      private readonly DeviceValue<float> _value;
      private readonly float _multiplier;
      private readonly float _offset;

      public MultiplyShiftDeviceValueImpl(DeviceValue<float> value, float multiplier, float offset) {
         _value = value;
         _multiplier = multiplier;
         _offset = offset;
      }

      public float Get() {
         return (_value.Get() - _offset) / _multiplier;
      }

      public void Set(float value) {
         _value.Set(value * _multiplier + _offset);
      }
   }
}