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

        public static readonly Vector3 DAY_ROTATION =  new Vector3(50f, 0f, 0f);
        public static readonly Vector3 NIGHT_ROTATION = new Vector3(-15f, 0f, 0f);
    }

    public static class SkillConst
    {
        public const float SKILL_COOLDOWN = 3f;
        public const float SKILL_MOVEMENTSPEED = 5f;
        public const float SKILL_CLICKED_FILL_AMOUNT = 0.4f;
        public const float SKILL_NORMAL_FILL_AMOUNT = 1f;
        public const float SKILL_DESTROY_TIME = 5f;
    }

    public static class InventoryItem
    {
        public const string ITEM_SWORD = "Sword";
        public const string ITEM_STAFF = "Staff";
        public const string ITEM_POTION = "Potion";
        public const string ITEM_RAPTOR = "Raptor";
        public const string ITEM_GOLD = "Gold";
        public const string ITEM_GEM = "Gem";
        public const string ITEM_SAND = "Sand";
    }

}
