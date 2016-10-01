using Dargon.Robotics.Devices;
using Dargon.Robotics.Devices.Components;
using Dargon.Robotics.Devices.Values.Util;
using MathNet.Numerics.LinearAlgebra.Single;

namespace Dargon.Robotics.Subsystems.DriveTrain.Holonomic {
   public interface HolonomicCalculator {
      HolonomicDriveValues TankDrive(float left, float right, bool inputsSquared = false);
      HolonomicDriveValues MecanumDrive(HolonomicDriveTrain driveTrain, float x, float y, bool inputsSquared = false);
   }

   public class HolonomicCalculatorImpl : HolonomicCalculator {
      public HolonomicDriveValues TankDrive(float left, float right, bool inputsSquared = false) {
         left = InputUtilities.TransformWithWarning(left, square: inputsSquared);
         right = InputUtilities.TransformWithWarning(right, square: inputsSquared);

         return new HolonomicDriveValues {
            FrontLeft = left,
            FrontRight = right,
            RearLeft = left,
            RearRight = right
         };
      }

      public HolonomicDriveValues MecanumDrive(HolonomicDriveTrain driveTrain, float x, float y, bool inputsSquared = false) {
         x = InputUtilities.TransformWithWarning(x, square: inputsSquared);
         y = InputUtilities.TransformWithWarning(y, square: inputsSquared);

         var desiredMovement = new DenseVector(new [] { x, y });
//         var desiredMovement = new DenseVector(new [] { 1f, 0f });
         HolonomicDriveValues result = new HolonomicDriveValues();
         result.FrontLeft = ComputeMecanumDriveMotorSpeed(desiredMovement, driveTrain.FrontLeft.GetComponent<VectorComponent>(DeviceComponentType.DriveWheelForceVector));
         result.FrontRight = ComputeMecanumDriveMotorSpeed(desiredMovement, driveTrain.FrontRight.GetComponent<VectorComponent>(DeviceComponentType.DriveWheelForceVector));
         result.RearLeft = ComputeMecanumDriveMotorSpeed(desiredMovement, driveTrain.RearLeft.GetComponent<VectorComponent>(DeviceComponentType.DriveWheelForceVector));
         result.RearRight = ComputeMecanumDriveMotorSpeed(desiredMovement, driveTrain.RearRight.GetComponent<VectorComponent>(DeviceComponentType.DriveWheelForceVector));
         return result;
      }

      private float ComputeMecanumDriveMotorSpeed(DenseVector desiredMovement, VectorComponent wheelForceVectorInput) {
         var wheelForceVector = new DenseVector(new[] { wheelForceVectorInput.X, wheelForceVectorInput.Y });
         var wheelForceVectorUnit = wheelForceVector.Normalize(2);
         var scale = wheelForceVectorUnit.DotProduct(desiredMovement);
//         Console.WriteLine(wheelForceVector + " " + wheelForceVectorUnit + " " + desiredMovement + " " + scale);
         return scale;
      }
   }
}
