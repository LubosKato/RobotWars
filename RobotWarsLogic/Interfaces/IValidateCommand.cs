namespace RobotWarsLogic.Interfaces
{
    public interface IValidateCommand
    {
        bool IsValid(char command);
        bool IsRightCommand(string command);
        bool IsLeftCommand(string command);
        bool IsMoveCommand(string command);
    }
}