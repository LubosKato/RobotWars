namespace RobotWarsLogic.Interfaces
{
    public interface ICommand
    {
        bool Execute(char command, IRobotWars robot);
    }
}