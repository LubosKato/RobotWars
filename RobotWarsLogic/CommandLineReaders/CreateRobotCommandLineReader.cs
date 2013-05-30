using System;
using RobotWarsLogic.Constants;
using RobotWarsLogic.Enums;
using RobotWarsLogic.Helpers;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.CommandLineReaders
{
    public class CreateRobotCommandLineReader : ICommandLineReader
    {
        private readonly IContext context;

        public CreateRobotCommandLineReader(IContext context)
        {
             this.context = context;
        }

        public bool Process(string command)
        {
            var result = string.Empty;
            try
            {
                if (!new ValidateCommandLine(Constant.CheckRobotRegex).Validate(command))
                {
                    return false;
                }

                string[] words = command.Split(' ');
                uint xAxis = Convert.ToUInt32(words[0]);
                uint yAxis = Convert.ToUInt32(words[1]);
                Direction direction = Helper.ConvertToDirection(words[2]);
                this.context.Robot = new RobotWars().EnterArena(this.context.Arena, xAxis, yAxis, direction);

                if (this.context.Robot == null)
                {
                    return false;
                }

                result = String.Format("Robot creation {0}", this.context.Robot != null ? "successful" : "failed");
            }
            catch (Exception)
            {
                result = "Robot creation failed";
                throw;
            }
            finally
            {
                Console.WriteLine(result);
            }
            return true;
        }


    }
}