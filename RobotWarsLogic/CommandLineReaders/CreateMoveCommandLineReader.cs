using System;
using System.Globalization;
using System.Linq;
using RobotWarsLogic.Commands;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.CommandLineReaders
{
    public class CreateMoveCommandLineReader : ICommandLineReader
    {
        private readonly IContext _context;
        readonly IValidateCommand _validation;

        public CreateMoveCommandLineReader(IContext context)
        {
             this._context = context;
             _validation = new ValidateCommand();
        }

        private bool Validate(string command)
        {
            command = command.Replace(" ", string.Empty);
            return command.All(s => _validation.IsValid(s));
        }

        public bool Process(string commands)
        {
            var result = string.Empty;
            bool moveDone = false;
            try
            {
                if (!this.Validate(commands))
                {
                    return false;
                }
                IRobotWars robot = this._context.Robot;
                foreach (var command in commands.ToLowerInvariant())
                {
                    if (!_validation.IsValid(command))
                        return false;
                    moveDone = ExecuteInternal(command, robot, _validation);
                }
                if(moveDone)
                result = "Robot movement completed \n";
                result += string.Format("Robot Position: {0} {1} {2}", robot.XAxis, robot.YAxis, robot.Direction);
            }
            catch (Exception)
            {
                result = "Something went wrong while moving robot";
                throw;
            }
            finally
            {
                Console.WriteLine(result);
            }
            return true;
        }

        private bool ExecuteInternal(char character, IRobotWars robot, IValidateCommand validation)
        {
            if(validation.IsMoveCommand(character.ToString(CultureInfo.InvariantCulture)))
            {
                ICommand command = new MoveCommand();
                command.Execute(character, robot);
            }
            else
            {
                ICommand command = new SpinCommand();
                command.Execute(character, robot);
            }
            return true;
        }
    }
}