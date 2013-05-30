using NUnit.Framework;
using Rhino.Mocks;
using RobotWarsLogic.Commands;

namespace RobotWarsTests.CommandsTests
{
    [TestFixture]
    public class SpinCommandTests : TestSetupBase
    {
        private SpinCommand command;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            this.command = new SpinCommand();
        }

        [Test]
        public void Execute_RobotIsNull_ReturnFalse()
        {
            bool result = this.command.Execute('R', null);
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
            var result = this.command.Execute('r', robotStub);
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_RobotSupplied_ReturnTrue()
        {
            bool result = this.command.Execute('R', robotStub);
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_RobotSupplied_SpinLeftCalledOnRobot()
        {
            command.Execute('L', robotStub);
            robotStub.AssertWasCalled(s => s.Spin(false), o => o.Repeat.Once());
        }

        [Test]
        public void Execute_RobotSupplied_SpinRightCalledOnRobot()
        {
            command.Execute('R', robotStub);
            robotStub.AssertWasCalled(s => s.Spin(true), o => o.Repeat.Once());
        }

        [Test]
        public void Execute_LowerCaseRobotSupplied_SpinLeftCalledOnRobot()
        {
            command.Execute('l', robotStub);
            robotStub.AssertWasCalled(s => s.Spin(false), o => o.Repeat.Once());
        }

        [Test]
        public void Execute_LowerCaseRobotSupplied_SpinRightCalledOnRobot()
        {
            command.Execute('r', robotStub);
            robotStub.AssertWasCalled(s => s.Spin(true), o => o.Repeat.Once());
        }
    }
}