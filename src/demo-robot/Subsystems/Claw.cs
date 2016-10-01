using System;
using Dargon.Robotics.Devices;
using NLog.LayoutRenderers;

namespace Dargon.Robotics.Demo.Subsystems {
   public class Claw {
      private readonly IServo wristServo;
      private readonly IServo leftHandServo;
      private readonly IServo rightHandServo;
      private readonly IServo elbowServo;

      private readonly float minWristDegrees;
      private readonly float maxWristDegrees;
      private readonly float minGripDegrees;
      private readonly float maxGripDegrees;
      private readonly float minDirectionalDegrees;
      private readonly float maxDirectionalDegrees;

      private float gripDegrees;
      private float directionalDegrees;

      public Claw(IServo wristServo, IServo leftHandServo, IServo rightHandServo, IServo elbowServo, float minWristDegrees, float maxWristDegrees, float minGripDegrees, float maxGripDegrees, float minDirectionalDegrees, float maxDirectionalDegrees) {
         this.wristServo = wristServo;
         this.leftHandServo = leftHandServo;
         this.rightHandServo = rightHandServo;
         this.elbowServo = elbowServo;
         this.minWristDegrees = minWristDegrees;
         this.maxWristDegrees = maxWristDegrees;
         this.minGripDegrees = minGripDegrees;
         this.maxGripDegrees = maxGripDegrees;
         this.minDirectionalDegrees = minDirectionalDegrees;
         this.maxDirectionalDegrees = maxDirectionalDegrees;

         // jank
         SetWristDegrees(0);
      }

      public IServo ElbowServo => elbowServo;

      public float GetWristDegrees() => wristServo.Get() - 100;

      public void SetWristDegrees(float value) {
         if (value < minWristDegrees) {
            value = minWristDegrees;
         } else if (value > maxWristDegrees) {
            value = maxWristDegrees;
         }
         wristServo.Set(value + 100);
         Console.WriteLine($"WRIST DEGREES " + (value + 100));
      }

      public float GetGripDegrees() => gripDegrees;

      public void SetGripDegrees(float value) {
         this.gripDegrees = Math.Min(maxGripDegrees, Math.Max(value, minGripDegrees));
         Update();
      }

      public float GetDirectionalDegrees() => directionalDegrees;

      public void SetDirectionalDegrees(float value) {
         this.directionalDegrees = Math.Min(maxDirectionalDegrees, Math.Max(value, minDirectionalDegrees));
         Update();
      }

      public void Reset() {
         SetWristDegrees(0);
         SetGripDegrees(0);
         SetDirectionalDegrees(0);
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
         leftHandServo.Set(leftClawDegrees + 50);
         rightHandServo.Set(-rightClawDegrees + 50);

         Console.WriteLine($"{directionalDegrees} {gripDegrees} // {leftClawDegrees + 100} {-rightClawDegrees + 100}");
      }
   }
}