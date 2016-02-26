using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dargon.Robotics.Devices.Common {
   public class IntegerAsFloatDeviceValueAdapter : DeviceValue<float> {
      private readonly DeviceValue<int> _deviceValue;
      private readonly int _offset;
      private readonly int _multiplier;

      public IntegerAsFloatDeviceValueAdapter(DeviceValue<int> deviceValue, int offset, int multiplier) {
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
