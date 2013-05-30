using NUnit.Framework;
using Rhino.Mocks;
using RobotWarsLogic;
using RobotWarsLogic.Enums;
using RobotWarsLogic.Interfaces;

namespace RobotWarsTests
{
    [TestFixture]
    public class TestSetupBase
    {
        protected IRobotWars robotStub;
        protected IArena arenaStub;
        protected IContext contextStub;
        protected const uint coordinate = 5;
        protected const uint validCoordinate = 3;
        protected const uint invalidCoordinate = 10;
        protected uint XAxis = 5;
        protected uint YAxis = 5;

        protected RobotWars robot;

        [SetUp]
        public virtual void Setup()
        {
            this.arenaStub = MockRepository.GenerateStub<IArena>();
            this.arenaStub.Stub(c => c.Width).Return(coordinate);
            this.arenaStub.Stub(c => c.Height).Return(coordinate);

            this.robotStub = MockRepository.GenerateStub<IRobotWars>();
            this.robotStub.Stub(c => c.Direction).Return(Direction.South);

            this.contextStub = MockRepository.GenerateStub<IContext>();
            this.robot = new RobotWars();
        }

        public string BuildCommand(uint lat, uint lng, Direction direction)
        {
            string stringDirection;
            switch (direction)
            {
                case Direction.North:
                    stringDirection = "N";
                    break;
                case Direction.South:
                    stringDirection = "S";
                    break;
                case Direction.East:
                    stringDirection = "E";
                    break;
                default:
                    stringDirection = "W";
                    break;
            }

            return string.Format("{0} {1} {2}", lat, lng, stringDirection);
        }

    }
}