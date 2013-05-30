using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic
{
    public class Arena : IArena
    {
        public Arena(uint x, uint y)
        {
            Width = x;
            Height = y;
        }

        public uint Width { get; private set; }
        public uint Height { get; private set; } 
    }
}