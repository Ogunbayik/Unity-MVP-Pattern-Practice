using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel 
{
    public int ItemID { get; private set; }
    public string ItemName { get; private set; }

    public ItemModel(int itemID, string itemName)
    {
        ItemID = itemID;
        ItemName = itemName;
    }
}
