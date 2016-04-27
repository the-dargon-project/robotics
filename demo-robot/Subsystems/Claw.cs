using System;
using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Demo.Subsystems {
   public class Claw {
      private readonly Servo wristServo;
      private readonly Servo leftHandServo;
      private readonly Servo rightHandServo;

      private readonly float minWristDegrees;
      private readonly float maxWristDegrees;
      private readonly float minGripDegrees;
      private readonly float maxGripDegrees;
      private readonly float minDirectionalDegrees;
      private readonly float maxDirectionalDegrees;

      private float gripDegrees;
      private float directionalDegrees;

      public Claw(Servo wristServo, Servo leftHandServo, Servo rightHandServo, float minWristDegrees, float maxWristDegrees, float minGripDegrees, float maxGripDegrees, float minDirectionalDegrees, float maxDirectionalDegrees) {
         this.wristServo = wristServo;
         this.leftHandServo = leftHandServo;
         this.rightHandServo = rightHandServo;
         this.minWristDegrees = minWristDegrees;
         this.maxWristDegrees = maxWristDegrees;
         this.minGripDegrees = minGripDegrees;
         this.maxGripDegrees = maxGripDegrees;
         this.minDirectionalDegrees = minDirectionalDegrees;
         this.maxDirectionalDegrees = maxDirectionalDegrees;
      }

      public void SetWristDegrees(float value) {
         if (value < minWristDegrees) {
            value = minWristDegrees;
         } else if (value > maxWristDegrees) {
            value = maxWristDegrees;
         }
         wristServo.Set(value);
      }

      public void SetGripDegrees(float value) {
         this.gripDegrees = Math.Min(maxGripDegrees, Math.Max(value, minGripDegrees));
         Update();
      }

      public void SetDirectionalDegrees(float value) {
         this.directionalDegrees = Math.Min(maxDirectionalDegrees, Math.Max(value, minDirectionalDegrees));
         Update();
      }

      private void Update() {
         float halfGripDegrees = gripDegrees / 2;
         float leftClawDegrees = directionalDegrees - halfGripDegrees;
         float rightClawDegrees = directionalDegrees + halfGripDegrees;
         if (leftClawDegrees < minDirectionalDegrees) {
            var delta = minDirectionalDegrees - leftClawDegrees;
            leftClawDegrees += delta;
            rightClawDegrees += delta;
         }
         if (rightClawDegrees > maxDirectionalDegrees) {
            var delta = rightClawDegrees - maxDirectionalDegrees;
            leftClawDegrees += delta;
            rightClawDegrees += delta;
         }
         leftHandServo.Set(leftClawDegrees);
         rightHandServo.Set(rightClawDegrees);
      }
   }
}