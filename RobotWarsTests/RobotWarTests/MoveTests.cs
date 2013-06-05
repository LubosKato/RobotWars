using NUnit.Framework;
using RobotWarsLogic.Enums;

namespace RobotWarsTests.RobotWarTests
{
    [TestFixture]
    public class MoveTests : TestSetupBase
    {
        [Test]
        public void Move_RobotNotInArena_NoMovement()
        {
            this.robot.Move();
            Assert.AreEqual(0, this.robot.YAxis);
            Assert.AreEqual(0, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotFacingNorth_RobotYAxisIncreasesByOne()
        {
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.North);
            this.robot.Move();
            Assert.AreEqual(1, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotFacingEast_RobotLatitiudeIncreasesByOne()
        {
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.East);
            this.robot.Move();
            Assert.AreEqual(1, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotFacingSouth_YAxisDecreasesByOne()
        {
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.South);
            this.robot.Move();
            Assert.AreEqual(coordinate - 1, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotFacingWest_RobotLatitiudeDecreasesByOne()
        {
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.West);
            this.robot.Move();
            Assert.AreEqual(coordinate - 1, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotOnLeftEdgeOfArenaFacingWest_RobotDoesNotMove()
        {
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.West);
            this.robot.Move();
            Assert.AreEqual(0, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotOnBottomEdgeOfArenaFacingSouth_RobotDoesNotMove()
        {
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.South);
            this.robot.Move();
            Assert.AreEqual(0, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotOnTopEdgeOfArenaFacingNorth_RobotDoesNotMove()
        {
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.North);
            this.robot.Move();
            Assert.AreEqual(coordinate, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotOnRightEdgeOfArenaFacingEast_RobotDoesNotMove()
        {
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.East);
            this.robot.Move();
            Assert.AreEqual(coordinate, this.robot.XAxis);
        }
    }
}