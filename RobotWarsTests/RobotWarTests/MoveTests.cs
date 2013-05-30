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
            //Arrange
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.North);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(1, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotFacingEast_RobotLatitiudeIncreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.East);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(1, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotFacingSouth_YAxisDecreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.South);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(coordinate - 1, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotFacingWest_RobotLatitiudeDecreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.West);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(coordinate - 1, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotOnLeftEdgeOfArenaFacingWest_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.West);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(0, this.robot.XAxis);
        }

        [Test]
        public void Move_RobotOnBottomEdgeOfArenaFacingSouth_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, 0, 0, Direction.South);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(0, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotOnTopEdgeOfArenaFacingNorth_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.North);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(coordinate, this.robot.YAxis);
        }

        [Test]
        public void Move_RobotOnRightEdgeOfArenaFacingEast_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arenaStub, coordinate, coordinate, Direction.East);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(coordinate, this.robot.XAxis);
        }
    }
}