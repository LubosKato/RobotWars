namespace RobotWarsLogic.Interfaces
{
    public interface IContext
    {
        IArena Arena { get; set; }
        IRobotWars Robot { get; set; }
    }
}