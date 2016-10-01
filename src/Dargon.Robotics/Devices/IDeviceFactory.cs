namespace Dargon.Robotics.Devices {
   public interface IDeviceFactory {
      DigitalOutput DigitalOutput(int pin);
      IMotor PwmMotor(int pin, float tweenFactor, float speedMultiplier, bool flipped);
      IServo RemoteServo(string getUrl, string setUrl, float defaultAngle);
   }
}