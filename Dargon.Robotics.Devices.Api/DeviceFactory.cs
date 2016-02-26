namespace Dargon.Robotics.Devices {
   public interface DeviceFactory {
      DigitalOutput DigitalOutput(int pin);
      Motor PwmMotor(int pin);
   }
}