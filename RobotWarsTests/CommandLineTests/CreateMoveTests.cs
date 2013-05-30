using NUnit.Framework;
using Rhino.Mocks;
using RobotWarsLogic.CommandLineReaders;

namespace RobotWarsTests.CommandLineTests
{
    [TestFixture]
    public class CreateMoveTests : TestSetupBase
    {
        private CreateMoveCommandLineReader createMoveCommandLineReader;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            contextStub.Arena = arenaStub;
            robotStub.Arena = contextStub.Arena;
            contextStub.Robot = robotStub;
            this.createMoveCommandLineReader = new CreateMoveCommandLineReader(contextStub);
        }

        [Test]
        public void ProcessMoveRobotCommand_RobotAskedToMoveOnce_RobotMovesOnce()
        {
            bool result = this.createMoveCommandLineReader.Process("M");
            robotStub.AssertWasCalled(s => s.Move(), o => o.Repeat.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_RobotAskedToMoveFiveTimes_RobotMovesFiveTimes()
        {
            string command = "MMMMM";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Move(), o => o.Repeat.Times(5));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_InvalidCommand_RobotDoesNotMove()
        {
            string command = "G";
            bool result = this.createMoveCommandLineReader.Process(command);
            Assert.IsFalse(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotCommand_RobotRotatesClockwiseOnce()
        {
            string command = "R";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Spin(true), o => o.Repeat.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotFourTimes_RobotRotatesClockwiseFourTimes()
        {
            string command = "RRRR";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Spin(true), o => o.Repeat.Times(4));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotAnticlockwiseCommand_RobotRotatesAnticlockwiseOnce()
        {
            string command = "L";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Spin(false), o => o.Repeat.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_RotateRobotAnticlockwiseFourTimes_RobotRotatesAnticlockwiseFourTimes()
        {
            string command = "LLLL";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Spin(false), o => o.Repeat.Times(4));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessMoveRobotCommand_MoveRobotThreeTimesRotateRightOnceMoveTwice_RobotMovesThreeTimesThenRotatesClockwiseThenMovesTwice()
        {
            string command = "MMMRMM";
            bool result = this.createMoveCommandLineReader.Process(command);
            robotStub.AssertWasCalled(s => s.Move(), o => o.Repeat.Times(5));
            robotStub.AssertWasCalled(s => s.Spin(true), o => o.Repeat.Once());
            Assert.IsTrue(result);
        }
    }
}