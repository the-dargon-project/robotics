using System;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace Dargon.Robotics.Devices {
   public interface IPositionTracker : IUpdatableDevice {
      Vector2D Position { get; }
      Vector2D Velocity { get; }
   }

   public class TankDriveShaftEncodersAndYawGyroscopeBasedPositionTracker : DeviceBase, IPositionTracker {
      private readonly IGyroscope gyroscope;
      private readonly IIncrementalRotaryEncoder leftShaftEncoder;
      private readonly IIncrementalRotaryEncoder rightShaftEncoder;
      private readonly float wheelMetersPerShaftRadian;
      private float lastLeftShaftAngle;
      private float lastRightShaftAngle;
      private Vector2D position;
      private Vector2D velocity;

      public TankDriveShaftEncodersAndYawGyroscopeBasedPositionTracker(
         string name,
         IGyroscope gyroscope, 
         IIncrementalRotaryEncoder leftShaftEncoder, 
         IIncrementalRotaryEncoder rightShaftEncoder,
         float wheelMetersPerShaftRadian
      ) : base(name, DeviceType.PositionTracker) {
         this.gyroscope = gyroscope;
         this.leftShaftEncoder = leftShaftEncoder;
         this.rightShaftEncoder = rightShaftEncoder;
         this.wheelMetersPerShaftRadian = wheelMetersPerShaftRadian;
      }

      public Vector2D Position => position;
      public Vector2D Velocity => velocity;

      public void Initialize() {
         lastLeftShaftAngle = leftShaftEncoder.Angle;
         lastRightShaftAngle = rightShaftEncoder.Angle;
      }

      public void Update() {
         var theta = gyroscope.GetAngle();

         // capture device data
         var leftShaftAngle = leftShaftEncoder.Angle;
         var rightShaftAngle = rightShaftEncoder.Angle;
         var leftShaftAngularVelocity = leftShaftEncoder.AngularVelocity;
         var rightShaftAngularVelocity = rightShaftEncoder.AngularVelocity;

         Console.WriteLine(leftShaftAngle + " " + rightShaftAngle);

         // compute position from wheel displacement and gyro
         var deltaLeftShaftAngle = leftShaftAngle - lastLeftShaftAngle;
         var deltaRightShaftAngle = rightShaftAngle - lastRightShaftAngle;
         var forwardAlignedDisplacementMagnitude = wheelMetersPerShaftRadian * (deltaLeftShaftAngle + deltaRightShaftAngle) / 2.0f;
         var displacement = new Vector2D(0, forwardAlignedDisplacementMagnitude).Rotate(Angle.FromRadians(theta));
         position += displacement;

         // compute velocity from wheel rate and gyro.
         var forwardAlignedVelocityMagnitude = wheelMetersPerShaftRadian * (leftShaftAngularVelocity + rightShaftAngularVelocity) / 2.0f;
         velocity = new Vector2D(0, forwardAlignedVelocityMagnitude).Rotate(Angle.FromRadians(theta));

         // update last angle
         lastLeftShaftAngle = leftShaftAngle;
         lastRightShaftAngle = rightShaftAngle;
      }
   }
}