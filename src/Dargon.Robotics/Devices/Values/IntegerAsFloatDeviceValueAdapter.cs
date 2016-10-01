﻿namespace Dargon.Robotics.Devices.Values {
   public class IntegerAsFloatDeviceValueAdapter : IDeviceValue<float> {
      private readonly IDeviceValue<int> _deviceValue;
      private readonly int _offset;
      private readonly int _multiplier;

      public IntegerAsFloatDeviceValueAdapter(IDeviceValue<int> deviceValue, int offset, int multiplier) {
         _deviceValue = deviceValue;
         _offset = offset;
         _multiplier = multiplier;
      }

      public float Get() {
         return (_deviceValue.Get() + _offset) / (float)_multiplier;
      }

      public void Set(float value) {
         _deviceValue.Set((int)(value * _multiplier - _offset));
      }
   }
}
