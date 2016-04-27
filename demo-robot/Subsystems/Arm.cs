using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Demo.Subsystems {
   public class Arm {
      private readonly float minElbowDegrees;
      private readonly float maxElbowDegrees;

      private readonly Servo elbowServo;
      private readonly Servo inOutServo;

      public Arm(Servo elbowServo, Servo inOutServo) {
         this.elbowServo = elbowServo;
         this.inOutServo = inOutServo;
      }

      public void SetElbowDegrees(float value) {
         if (value < minElbowDegrees) {
            value = minElbowDegrees;
         } else if (value > maxElbowDegrees) {
            value = maxElbowDegrees;
         }
         elbowServo.Set(value);
      }

   }
}
