using Dargon.Robotics.Devices;

namespace Dargon.Robotics.Subsystems.DriveTrain.Vertical {
	public class VerticalDriveTrain {
		private readonly Motor frontLeft;
		private readonly Motor frontRight;
		private readonly Motor rear;

		public VerticalDriveTrain(Motor frontLeft, Motor frontRight, Motor rear) {
			this.frontLeft = frontLeft;
			this.frontRight = frontRight;
			this.rear = rear;
		}

		public Motor FrontLeft => frontLeft;
		public Motor FrontRight => frontRight;
	   public Motor Rear => rear;

		public void SetValues(VerticalDriveValues values) {
			SetValues(values.FrontLeft, values.FrontRight, values.Rear);
		}

		public void SetValues(float frontLeftSpeed, float frontRightSpeed, float rearSpeed) {
			frontLeft.Set(frontLeftSpeed * frontLeftSpeed * frontLeftSpeed);
			frontRight.Set(frontRightSpeed * frontRightSpeed * frontRightSpeed);
			rear.Set(rearSpeed * rearSpeed * rearSpeed);
		}
	}
}
