using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
    public static class HealthConst
    {
        public const int TEST_DAMAGE = 15;
    }

    public static class DayConst
    {
        public const string DAY = "Day";
        public const string NIGHT = "Night";

        public static readonly Vector3 DAY_ROTATION =  new Vector3(-15f, 0f, 0f);
        public static readonly Vector3 NIGHT_ROTATION = new Vector3(50f, 0f, 0f);
    }
}
