using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dargon.Robotics.Devices;
using Dargon.Robotics.Devices.Common;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class SimulationMotorAdapter : DeviceBase, Motor {
      private readonly SimulationMotorState simulationMotorState;
      private float lastValue = 0.0f;

      public SimulationMotorAdapter(SimulationMotorState simulationMotorState) : base(simulationMotorState.Name, DeviceType.Motor) {
         this.simulationMotorState = simulationMotorState;
      }

      public void Set(float value) {
         value = InputUtilities.ClampWithWarning(value);
         simulationMotorState.CurrentForceVector = simulationMotorState.MaxForceVector * value;
         lastValue = value;
      }

      public float GetLastValue() => lastValue;
   }
}
