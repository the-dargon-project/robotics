namespace Dargon.Robotics.Devices.DriveTrain.Vertical {
	public class VerticalDriveTrain {
		private readonly IMotor frontLeft;
		private readonly IMotor frontRight;
		private readonly IMotor rear;

		public VerticalDriveTrain(IMotor frontLeft, IMotor frontRight, IMotor rear) {
			this.frontLeft = frontLeft;
			this.frontRight = frontRight;
			this.rear = rear;
		}

		public IMotor FrontLeft => frontLeft;
		public IMotor FrontRight => frontRight;
	   public IMotor Rear => rear;

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
