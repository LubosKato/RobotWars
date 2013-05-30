using RobotWarsLogic.Enums;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic
{
    public class RobotWars : IRobotWars
    {
        public RobotWars()
        {
            Direction = Direction.North;
        }

        public Direction Direction { get; private set; }
        public uint XAxis { get; private set; }
        public uint YAxis { get; private set; }
        public IArena Arena { get; set; }

        /// <summary>
        /// Move robot 1 step ahead
        /// </summary>
        public void Move()
        {
            if (this.Arena == null)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.North:
                    if (this.YAxis < this.Arena.Height)
                    {
                        this.YAxis++;
                    }
                    break;
                case Direction.East:
                    if (this.XAxis < this.Arena.Width)
                    {
                        this.XAxis++;
                    }
                    break;
                case Direction.South:
                    if (this.YAxis > 0)
                    {
                        this.YAxis--;
                    }
                    break;
                case Direction.West:
                    if (this.XAxis > 0)
                    {
                        this.XAxis--;
                    }
                    break;
            }
        }

        /// <summary>
        /// Spin the robot 90 degrees to the left or right 
        /// </summary>
        public void Spin(bool clockwise = true)
        {
            if (clockwise)
            {
                this.Direction = this.Direction == Direction.West ? Direction.North
                                                                       : (Direction)(((int)this.Direction) << 1);
            }
            else
            {
                this.Direction = this.Direction == Direction.North ? Direction.West
                                                                        : (Direction)(((int)this.Direction) >> 1);
            }
        }

        public RobotWars EnterArena(IArena arena, uint x, uint y, Direction direction)
        {
            if (arena == null || x > arena.Width || y > arena.Height)
            {
                return null;
            }

            this.Arena = arena;
            this.XAxis = x;
            this.YAxis = y;
            this.Direction = direction;

            return this;
        }
    }
}