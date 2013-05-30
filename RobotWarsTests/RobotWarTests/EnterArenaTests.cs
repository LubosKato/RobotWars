using NUnit.Framework;
using RobotWarsLogic;
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
            RobotWars success = robot.EnterArena(this.arenaStub, invalidCoordinate, validCoordinate, Direction.North);
            Assert.IsNull(success);
        }

        [Test]
        public void EnterArena_ValidCoordinates_ReturnTrue()
        {
            RobotWars success = robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, Direction.North);
            Assert.NotNull(success);
        }

        [Test]
        public void EnterArena_InvalidYCoordinate_ReturnFalse()
        {
            RobotWars success = robot.EnterArena(this.arenaStub, validCoordinate, invalidCoordinate, Direction.North);
            Assert.IsNull(success);
        }

        [Test]
        public void EnterArena_ArenaIsNull_ReturnFalse()
        {
            RobotWars success = robot.EnterArena(null, validCoordinate, invalidCoordinate, Direction.North);
            Assert.IsNull(success);
        }

        [Test]
        public void EnterArena_DirectionIsEast_RobotDirectionIsSet()
        {
            var robotDirection = Direction.East;
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, robotDirection);
            Assert.AreEqual(robotDirection, robot.Direction);
        }

        [Test]
        public void EnterArena_DirectionIsSouth_RobotDirectionIsSet()
        {
            var robotDirection = Direction.South;
            robot.EnterArena(this.arenaStub, validCoordinate, validCoordinate, robotDirection);
            Assert.AreEqual(robotDirection, robot.Direction);
        }
    }
}