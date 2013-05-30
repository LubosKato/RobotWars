using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.Commands
{
    public class MoveCommand : ICommand
    {
        public bool Execute(char command, IRobotWars robot)
        {
            var validate = new ValidateCommand();
            if (robot == null || !validate.IsValid(command)) 
            { return false; }

            robot.Move();
            return true;
        } 
    }
}