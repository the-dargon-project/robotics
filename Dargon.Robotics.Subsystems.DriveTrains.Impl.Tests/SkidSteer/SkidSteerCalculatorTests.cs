using System;
using System.Diagnostics;
using NMockito;
using Xunit;

namespace Dargon.Robotics.Subsystems.DriveTrains.SkidSteer {
   public class SkidSteerCalculatorTests : NMockitoInstance {
      private readonly SkidSteerCalculatorImpl testObj = new SkidSteerCalculatorImpl();

      [Fact]
      public void TankDrive_NonsquaredInput_HappyPath() {
         AssertEquals(new SkidDriveValues(0.50f, -0.50f), testObj.TankDrive(0.5f, -0.5f, false));
      }

      [Fact]
      public void TankDrive_SquaredInput_HappyPath() {
         AssertEquals(new SkidDriveValues(0.25f, -0.25f), testObj.TankDrive(0.5f, -0.5f));
      }

      [Fact]
      public void ArcadeDrive_Stationary_Test() {
         AssertEquals(new SkidDriveValues(0.0f, 0.0f), testObj.ArcadeDrive(0.0f, 0.0f));
      }

      [Fact]
      public void ArcadeDrive_Forward_Test() {
         AssertEquals(new SkidDriveValues(1.0f, 1.0f), testObj.ArcadeDrive(1.0f, 0.0f));
      }

      [Fact]
      public void ArcadeDrive_Backward_Test() {
         AssertEquals(new SkidDriveValues(-1.0f, -1.0f), testObj.ArcadeDrive(-1.0f, 0.0f));
      }

      [Fact]
      public void ArcadeDrive_Left_Test() {
         AssertEquals(new SkidDriveValues(-1.0f, 1.0f), testObj.ArcadeDrive(0.0f, -1.0f));
      }

      [Fact]
      public void ArcadeDrive_Right_Test() {
         AssertEquals(new SkidDriveValues(1.0f, -1.0f), testObj.ArcadeDrive(0.0f, 1.0f));
      }

      [Fact]
      public void ArcadeDrive_ForwardRight_Test() {
         AssertEquals(new SkidDriveValues(1.0f, 0.0f), testObj.ArcadeDrive(1.0f, 1.0f));
      }

      [Fact]
      public void ArcadeDrive_ForwardLeft_Test() {
         AssertEquals(new SkidDriveValues(0.0f, 1.0f), testObj.ArcadeDrive(1.0f, -1.0f));
      }

      [Fact]
      public void ArcadeDrive_BackwardRight_Test() {
         AssertEquals(new SkidDriveValues(-1.0f, 0), testObj.ArcadeDrive(-1.0f, 1.0f));
      }

      [Fact]
      public void ArcadeDrive_BackwardLeft_Test() {
         AssertEquals(new SkidDriveValues(0, -1.0f), testObj.ArcadeDrive(-1.0f, -1.0f));
      }

      private void AssertEquals(SkidDriveValues expected, SkidDriveValues actual) {
         Debug.WriteLine($"Expected: {expected.Left} {expected.Right} vs Actual: {actual.Left} {actual.Right}.");

         AssertEquals(expected.Left, actual.Left);
         AssertEquals(expected.Right, actual.Right);
      }
   }
}
