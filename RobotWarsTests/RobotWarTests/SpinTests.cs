using NUnit.Framework;
using RobotWarsLogic.Enums;


namespace RobotWarsTests.RobotWarTests
{
    [TestFixture]
    public class SpinTests : TestSetupBase
    {
        private void SetDirection(Direction direction)
        {
            this.robot.EnterArena(arenaStub, 0, 0, direction);
        }

        [Test]
        public void Rotate_RobotFacingNorth_RobotFacingEast()
        {
            this.SetDirection(Direction.North);
            robot.Spin();
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingEast_RobotFacingSouth()
        {
            this.SetDirection(Direction.East);
            robot.Spin();
            Assert.AreEqual(Direction.South, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingSouth_RobotFacesWest()
        {
            this.SetDirection(Direction.South);
            robot.Spin();
            Assert.AreEqual(Direction.West, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingWest_RobotFacesNorth()
        {
            this.SetDirection(Direction.West);
            robot.Spin();
            Assert.AreEqual(Direction.North, robot.Direction);
        }

        [Test]
        public void RotateAnticlockwise_RobotFacingNorth_RobotFacesWest()
        {
            this.SetDirection(Direction.North);
            robot.Spin(false);
            Assert.AreEqual(Direction.West, robot.Direction);
        }

        [Test]
        public void RotateAnticlockwise_RobotFacingEast_RobotFacesNorth()
        {
            this.SetDirection(Direction.East);
            robot.Spin(false);
            Assert.AreEqual(Direction.North, robot.Direction);
        }
    }
}