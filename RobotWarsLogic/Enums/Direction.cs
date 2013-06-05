using System;

namespace RobotWarsLogic.Enums
{
    [Flags]
    public enum Direction
    {
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }
}