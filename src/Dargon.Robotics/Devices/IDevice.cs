using Dargon.Commons.Collections;

namespace Dargon.Robotics.Devices {
   public interface IDevice {
      string Name { get; }
      DeviceType Type { get; }
      TComponent GetComponent<TComponent>(DeviceComponentType type);
   }

   public class DeviceBase : IDevice {
      private readonly IConcurrentDictionary<DeviceComponentType, object> componentsByType = new ConcurrentDictionary<DeviceComponentType, object>();

      public DeviceBase(string name, DeviceType type) {
         Name = name;
         Type = type;
      }

      public string Name { get; }
      public DeviceType Type { get; }
      public TComponent GetComponent<TComponent>(DeviceComponentType type) => (TComponent)componentsByType[type];
      public void AddComponent<TComponent>(DeviceComponentType type, TComponent component) => componentsByType.Add(type, component);
   }

   public enum DeviceComponentType {
      DriveWheelForceVector = 1
   }

   public enum DeviceType : uint {
      None = 0,
      AnalogInput    = 0x00000001U,
      AnalogOutput   = 0x00000002U,
      RotaryEncoder  = 0x00000004U,
      Motor          = 0x00000008U,
      DigitalOutput  = 0x00000010U,
      Accumulator    = 0x00000020U,
      Accelerometer  = 0x00000040U,
      Gyroscope      = 0x00000080U,
      Servo          = 0x00000100U,
      PositionTracker = 0x00000200U,
   }
}
