using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Demo.Subsystems {
   public class Arm {
      private readonly float minElbowDegrees;
      private readonly float maxElbowDegrees;

      private readonly IServo elbowServo;
      private readonly IServo inOutServo;

      public Arm(IServo elbowServo, IServo inOutServo) {
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
