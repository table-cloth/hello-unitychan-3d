using UnityEngine;
using System.Collections;

public class Const
{

    public class Tag
    {
        public const string UnityChan = "UnityChan";
        public const string Obstacle = "Obstacle";
    }

    public class ObjectType
    {
        public const int Obstacle = 0;
        public const int Item = 1;
    }

    public class Animation
    {
        public const string Jump2Top = "JumpToTop";
        public const string Jump2Ground = "TopToGround";
    }

    public class AnimatorState
    {
        public const string Run = "Running";
        public const string Jump2Top = "ToTop";
        public const string FallBack = "GoDown";

    }
}
