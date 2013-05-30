using System;
using RobotWarsLogic.Constants;
using RobotWarsLogic.Interfaces;

namespace RobotWarsLogic.CommandLineReaders
{
    public class CreateArenaCommandLineReader : ICommandLineReader
    {
        private readonly IContext context;

        public CreateArenaCommandLineReader(IContext context)
        {
            this.context = context;
        }

        public bool Process(string command)
        {
            if (!new ValidateCommandLine(Constant.CheckArenaRegex).Validate(command))
            {
                return false;
            }
            var result = string.Empty;
            try
            {
                string[] words = command.Split(' ');
                uint width = Convert.ToUInt32(words[0]);
                uint height = Convert.ToUInt32(words[1]);
                this.context.Arena = new Arena(width, height);
                result = "Arena creation successful";
            }
            catch (Exception)
            {
                result = "Arena creation failed";
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