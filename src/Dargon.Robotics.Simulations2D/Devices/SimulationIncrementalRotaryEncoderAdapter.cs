using Dargon.Robotics.Devices;
using System;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class SimulationIncrementalRotaryEncoderAdapter : DeviceBase, IIncrementalRotaryEncoder {
      private readonly SimulationWheelShaftEncoderState state;
      private readonly float radiansPerTick;

      public SimulationIncrementalRotaryEncoderAdapter(SimulationWheelShaftEncoderState state, float ticksPerRevolution) : base(state.Name, DeviceType.RotaryEncoder) {
         this.state = state;
         this.radiansPerTick = (float)(2.0 * Math.PI / ticksPerRevolution);
      }

      public int Ticks => (int)(state.Angle / radiansPerTick);
      public float Rate => (float)(state.AngularVelocity / radiansPerTick);

      // Derive from discretized values
      public float Angle => Ticks * radiansPerTick;
      public float AngularVelocity => Rate * radiansPerTick;
   }
}
