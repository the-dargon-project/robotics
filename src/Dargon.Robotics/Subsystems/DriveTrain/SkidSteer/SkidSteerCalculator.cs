using System;

namespace Dargon.Robotics.Subsystems.DriveTrain.SkidSteer {
   public interface SkidSteerCalculator {
      SkidDriveValues TankDrive(float leftStick, float rightStick, bool inputsSquared = false);
   }

   public class SkidSteerCalculatorImpl : SkidSteerCalculator {
      public SkidDriveValues TankDrive(float leftStick, float rightStick, bool inputsSquared = false) {
         if (inputsSquared) {
            leftStick = leftStick * Math.Abs(leftStick);
            rightStick = rightStick * Math.Abs(rightStick);
         }
         return new SkidDriveValues(leftStick, rightStick);
      }

      public SkidDriveValues ArcadeDrive(float forward, float turn) {
         float leftForward = forward, rightForward = forward;
         float leftTurn = forward >= 0 ? turn : -turn;
         float rightTurn = -leftTurn;
         float scale = Math.Abs(forward) + Math.Abs(turn);
         if (scale < float.Epsilon) {
            return SkidDriveValues.kZero;
         }
         float amplitude = Math.Max(Math.Abs(forward), Math.Abs(turn));
         var left = (leftForward + leftTurn) * amplitude / scale;
         var right = (rightForward + rightTurn) * amplitude / scale;
         return new SkidDriveValues(left, right);
      }
   }
}
