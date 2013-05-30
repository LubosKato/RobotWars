using NUnit.Framework;
using Rhino.Mocks;
using RobotWarsLogic;
using RobotWarsLogic.CommandLineReaders;

namespace RobotWarsTests.CommandLineTests
{
    [TestFixture]
    public class CreateArenaTests : TestSetupBase
    {
        private CreateArenaCommandLineReader createArenaCommandLineReader;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            this.createArenaCommandLineReader = new CreateArenaCommandLineReader(this.contextStub);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoSingleDigitNumbersSeperatedBySpaceSupplied_CreateArena()
        {
            bool result = this.createArenaCommandLineReader.Process(string.Format("{0} {1}", XAxis, YAxis));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoSingleDigitNumbersSeperatedBySpaceSupplied_SetArena()
        {
            var arena = new Arena(XAxis, YAxis);
            this.createArenaCommandLineReader.Process(string.Format("{0} {1}", XAxis, YAxis));
            Assert.AreEqual(arena.Width, this.contextStub.Arena.Width);
            Assert.AreEqual(arena.Height, this.contextStub.Arena.Height);
        }

        [Test]
        public void ProcessSetupArenaCommand_EmptyCommandSupplied_ArenaNotCreated()
        {

            bool result = this.createArenaCommandLineReader.Process(string.Empty);
            Assert.IsFalse(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersSeperatedBySpaceSupplied_CreateArenaWithCorrectXAxis()
        {
            bool result = this.createArenaCommandLineReader.Process(string.Format("{0} {1}", XAxis, YAxis));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_OneLargeNumberSeperatedBySpaceSupplied_CreateArenaWithCorrectXAxis()
        {
            const int largeXAxis = int.MaxValue;
            bool result = this.createArenaCommandLineReader.Process(string.Format("{0} {1}", largeXAxis, YAxis));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersSeperatedBySpaceSupplied_CreateArenaWithCorrectYAxis()
        {
            bool result = this.createArenaCommandLineReader.Process(string.Format("{0} {1}", XAxis, YAxis));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_LargeYAxisNumberSupplied_CreateArenaWithCorrectYAxis()
        {
            const int largeYAxis = 100;
            bool result = this.createArenaCommandLineReader.Process(string.Format("{0} {1}", XAxis, largeYAxis));
            Assert.IsTrue(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_InvalidSingleArgumentCommandSent_ArenaIsNotCreated()
        {
            bool result = this.createArenaCommandLineReader.Process("5");
            Assert.IsFalse(result);
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoLettersSeparatedBySpace_ArenaIsNotCreated()
        {
            Assert.IsFalse(this.createArenaCommandLineReader.Process("A B"));
        }

        [Test]
        public void ProcessSetupArenaCommand_TwoNumbersAndALetter_ArenaIsNotCreated()
        {
            Assert.IsFalse(this.createArenaCommandLineReader.Process("1 2 N"));
        }
    }
}