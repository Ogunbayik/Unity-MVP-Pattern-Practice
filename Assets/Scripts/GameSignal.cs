using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSignal 
{
    public class DayNightChangeSignal
    {
        public bool IsNight;

        public DayNightChangeSignal(bool isNight)
        {
            IsNight = isNight;
        }
    }

    public class RemoveSlotSignal
    {
        public int SlotID;

        public RemoveSlotSignal(int slotID)
        {
            SlotID = slotID;
        }

    }

}
