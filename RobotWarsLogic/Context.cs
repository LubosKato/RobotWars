using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic
{
    public class Context : IContext
    {
            public IArena Arena { get; set; }
            public IRobotWars Robot { get; set; } 
    }
}