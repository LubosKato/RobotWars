using System;
using System.Globalization;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.Commands
{
    public class ValidateCommand : IValidateCommand
    {
        public bool IsValid(char command)
        {
            string commandAsString = command.ToString(CultureInfo.InvariantCulture);
            return this.IsLeftCommand(commandAsString)
                || this.IsRightCommand(commandAsString)
                || this.IsMoveCommand(commandAsString);
        }

        public bool IsRightCommand(string command)
        {
            return command.Equals(Constants.Constant.RightCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsLeftCommand(string command)
        {
            return command.Equals(Constants.Constant.LeftCommand, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsMoveCommand(string command)
        {
            return command.Equals(Constants.Constant.MoveCommand, StringComparison.InvariantCultureIgnoreCase);
        } 
    }
}