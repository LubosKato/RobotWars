using RobotWarsLogic.Enums;

namespace RobotWarsLogic.Helpers
{
    public static class Helper
    {
        public static Direction ConvertToDirection(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "e":
                    return Direction.East;
                case "s":
                    return Direction.South;
                case "w":
                    return Direction.West;
                default:
                    return Direction.North;
            }
        } 
    }
}