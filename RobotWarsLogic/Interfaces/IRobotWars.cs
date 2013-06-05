using RobotWarsLogic.Enums;

namespace RobotWarsLogic.Interfaces
{
    public interface IRobotWars
    {
        Direction Direction { get; }
        uint XAxis { get; }
        uint YAxis { get; }
        IArena Arena { get; set; }

        /// <summary>
        /// Move robot 1 step ahead
        /// </summary>
        void Move();

        /// <summary>
        /// Spin the robot 90 degrees to the left or right 
        /// </summary>
        void Spin(bool clockwise = true);

        bool EnterArena(IArena arena, uint x, uint y, Direction direction);
    }
}