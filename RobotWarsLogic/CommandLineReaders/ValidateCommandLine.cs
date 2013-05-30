using System.Text.RegularExpressions;

namespace RobotWarsLogic.CommandLineReaders
{
    public class ValidateCommandLine
    {
        private readonly Regex regex;

        public ValidateCommandLine(string pattern)
        {
            this.regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public bool Validate(string command)
        {
            return this.regex.IsMatch(command);
        }
    }
}