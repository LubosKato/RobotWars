using NUnit.Framework;
using Rhino.Mocks;
using RobotWarsLogic.Commands;

namespace RobotWarsTests.CommandsTests
{
    [TestFixture]
    public class MoveCommandTests : TestSetupBase
    {
        private MoveCommand command;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            this.command = new MoveCommand();
        }

        [Test]
        public void Execute_RobotIsNull_ReturnFalse()
        {
            bool result = this.command.Execute('M', null);
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_CommandNotSupplied_ReturnFalse()
        {
            var result = this.command.Execute(' ', robotStub);
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_CommandWorng_ReturnFalse()
        {
            var result = this.command.Execute('X', robotStub);
            Assert.IsFalse(result);
        }


        [Test]
        public void IsValid_PassValidLowecaseCharacter_ReturnTrue()
        {
            var result = this.command.Execute('m', robotStub);
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_RobotSupplied_ReturnTrue()
        {
            bool result = this.command.Execute('M', robotStub);
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_RobotSupplied_MoveCalledOnRobot()
        {
            command.Execute('M', robotStub);
            robotStub.AssertWasCalled(s => s.Move(), o => o.Repeat.Once());
        }
    }
}