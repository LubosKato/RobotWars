using NUnit.Framework;
using RobotWarsLogic.Enums;

namespace RobotWarsTests.RobotWarTests
{
    [TestFixture]
    public class EnterArenaTests : TestSetupBase
    {
        [Test]
        public void EnterArena_ValidArena_ArenaPropertySet()
        {
            robot.EnterArena(this.arenaStub, 0, 0, Direction.North);
            Assert.AreSame(arenaStub, robot.Arena);
        }

        [Test]
        public void EnterArena_ValidXCoordinate_RobotXAxisSet()
        {
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, Direction.North);
            Assert.AreEqual(validCoordinate, robot.XAxis);
        }

        [Test]
        public void EnterArena_ValidYCoordinate_RobotYAxisSet()
        {
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, Direction.North);
            Assert.AreEqual(validCoordinate, robot.YAxis);
        }

        [Test]
        public void EnterArena_InvalidXCoordinate_ReturnFalse()
        {
            bool success = robot.EnterArena(this.arenaStub, invalidCoordinate, validCoordinate, Direction.North);
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ValidCoordinates_ReturnTrue()
        {
            bool success = robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, Direction.North);
            Assert.IsTrue(success);
        }

        [Test]
        public void EnterArena_InvalidYCoordinate_ReturnFalse()
        {
            bool success = robot.EnterArena(this.arenaStub, validCoordinate, invalidCoordinate, Direction.North);
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ArenaIsNull_ReturnFalse()
        {
            bool success = robot.EnterArena(null, validCoordinate, invalidCoordinate, Direction.North);
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_DirectionIsEast_RobotDirectionIsSet()
        {
            const Direction robotDirection = Direction.East;
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, robotDirection);
            Assert.AreEqual(robotDirection, robot.Direction);
        }

        [Test]
        public void EnterArena_DirectionIsSouth_RobotDirectionIsSet()
        {
            const Direction robotDirection = Direction.South;
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, robotDirection);
            Assert.AreEqual(robotDirection, robot.Direction);
        }
    }
}