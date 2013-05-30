using System.Globalization;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.Commands
{
    public class SpinCommand : ICommand
    {
        private IValidateCommand _validate;

        public bool Execute(char command, IRobotWars robot)
        { 
            _validate = new ValidateCommand();
            if (robot == null || !_validate.IsValid(command))
                return false;
            this.ProcessCommand(command, robot);

            return true;
        }

        private void ProcessCommand(char command, IRobotWars robot)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            if (_validate.IsLeftCommand(commandAsString))
            {
                robot.Spin(false);
            }

            if (_validate.IsRightCommand(commandAsString))
            {
                robot.Spin(true);
            }
        } 
    }
}