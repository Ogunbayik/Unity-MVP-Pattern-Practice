using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryView 
{
    public Transform InventoryContainer { get; }

    public event Action OnClickedTakeButton;
    void AddSlot(InventroySlot slot);
    void RemoveSlot(int slotID);
    void ReSlotID();

}
