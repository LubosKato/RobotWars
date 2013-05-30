using NUnit.Framework;
using RobotWarsLogic.CommandLineReaders;
using RobotWarsLogic.Enums;

namespace RobotWarsTests.CommandLineTests
{
    [TestFixture]
    public class CreateRobotTests : TestSetupBase
    {
        private CreateRobotCommandLineReader createArenaCommandLineReader;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            contextStub.Arena = arenaStub;
            this.createArenaCommandLineReader = new CreateRobotCommandLineReader(this.contextStub);
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoDigitsAndADirectionSupplied_CreateRobot()
        {
            string command = this.BuildCommand(1, 2, Direction.North);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSent_RobotEntersArena()
        {
            const Direction robotDirection = Direction.North;
            string command = this.BuildCommand(XAxis, YAxis, robotDirection);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoDigitsAndADirectionSupplied_EnterArenaWithCorrectXAxis()
        {
            string command = this.BuildCommand(XAxis, 2, Direction.North);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectXAxis()
        {
            string command = this.BuildCommand(XAxis, YAxis, Direction.North);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectYAxis()
        {
            string command = this.BuildCommand(XAxis, YAxis, Direction.North);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ALetterADigitsAndADirectionSupplied_DoNotCreateRobot()
        {
            string command = "A 20 N";
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsFalse(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSent_EnterArenaWithCorrectYAxis()
        {
            string command = this.BuildCommand(XAxis, YAxis, Direction.North);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForSouth_EnterArenaWithCorrectDirection()
        {
            const Direction robotDirection = Direction.South;
            string command = this.BuildCommand(XAxis, YAxis, robotDirection);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForEast_EnterArenaWithCorrectDirection()
        {
            const Direction robotDirection = Direction.East;
            string command = this.BuildCommand(XAxis, YAxis, robotDirection);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForWest_EnterArenaWithCorrectDirection()
        {
            const Direction robotDirection = Direction.West;
            string command = this.BuildCommand(XAxis, YAxis, robotDirection);
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessCreateRobotCommand_InvalidDirectionSent_RobotNotCreated()
        {
            string command = "10 20 F";
            bool result = this.createArenaCommandLineReader.Process(command);
            Assert.IsFalse(result);
        }
    }
}