namespace Dargon.Robotics.Devices {
   public interface DeviceFactory {
      DigitalOutput DigitalOutput(int pin);
      Motor PwmMotor(int pin, float tweenFactor, float speedMultiplier, bool flipped);
      Servo RemoteServo(string getUrl, string setUrl, float defaultAngle);
   }
}