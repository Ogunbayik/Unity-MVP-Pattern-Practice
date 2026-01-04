using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IInventoryView
{
    public List<InventroySlot> slotList = new List<InventroySlot>();

    [SerializeField] private Button _takeButton;
    [SerializeField] private Transform _inventoryContainer;

    public event Action OnClickedTakeButton;

    void Start() => _takeButton.onClick.AddListener(() => OnClickedTakeButton?.Invoke());

    public void AddSlot(InventroySlot slot) => slotList.Add(slot);
    public void RemoveSlot(int slotID)
    {
        Destroy(slotList[slotID].gameObject);
        slotList.RemoveAt(slotID);
    }
    public void ReSlotID()
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            slotList[i].ReSlotID(i);
        }
    }
    public Transform InventoryContainer => _inventoryContainer;

}
