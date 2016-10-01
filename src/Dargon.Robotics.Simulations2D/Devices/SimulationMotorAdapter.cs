using Dargon.Robotics.Devices;
using Dargon.Robotics.Devices.Components;
using Dargon.Robotics.Devices.Values.Util;

namespace Dargon.Robotics.Simulations2D.Devices {
   public class SimulationMotorAdapter : DeviceBase, Motor {
      private readonly SimulationMotorState simulationMotorState;
      private float lastValue = 0.0f;

      public SimulationMotorAdapter(SimulationMotorState simulationMotorState) : base(simulationMotorState.Name, DeviceType.Motor) {
         this.simulationMotorState = simulationMotorState;
      }

      public void Initialize() {
         AddComponent(
            DeviceComponentType.DriveWheelForceVector,
            new VectorComponent(
               simulationMotorState.MaxForceVector.X,
               simulationMotorState.MaxForceVector.Y,
               0));
      }

      public void Set(float value) {
         value = InputUtilities.ClampWithWarning(value);
         simulationMotorState.CurrentForceVector = simulationMotorState.MaxForceVector * value;
         lastValue = value;
      }

      public float GetLastValue() => lastValue;
   }
}
