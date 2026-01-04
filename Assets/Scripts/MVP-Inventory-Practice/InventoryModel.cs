using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryModel
{
    private SignalBus _signalBus;

    private List<ItemModel> _avaliableItems = new List<ItemModel>();
    private List<ItemModel> _inventoryList = new List<ItemModel>();

    private int _inventoryCapacity;

    public event Action OnInventoryFulled;
    public event Action<ItemModel> OnItemAdded;
    public event Action<int> OnItemRemoved;
    public InventoryModel(int inventoryCapacity = 5)
    {
        _inventoryCapacity = inventoryCapacity;
        PopulateItemDataBase();
    }
    private void PopulateItemDataBase()
    {
        _avaliableItems.Add(new ItemModel(1, GameConstant.InventoryItem.ITEM_SWORD));
        _avaliableItems.Add(new ItemModel(2, GameConstant.InventoryItem.ITEM_STAFF));
        _avaliableItems.Add(new ItemModel(3, GameConstant.InventoryItem.ITEM_POTION));
        _avaliableItems.Add(new ItemModel(4, GameConstant.InventoryItem.ITEM_RAPTOR));
        _avaliableItems.Add(new ItemModel(5, GameConstant.InventoryItem.ITEM_GOLD));
        _avaliableItems.Add(new ItemModel(6, GameConstant.InventoryItem.ITEM_GEM));
        _avaliableItems.Add(new ItemModel(7, GameConstant.InventoryItem.ITEM_SAND));
    }
    public void TryAddRandomItem()
    {
        if(_inventoryList.Count >= _inventoryCapacity)
        {
            OnInventoryFulled?.Invoke();
            return;
        }

        var item = GetRandomItem();
        _inventoryList.Add(item);
        OnItemAdded?.Invoke(item);
        Debug.Log(item.ItemName);
    }
    public void RemoveItem(int slotID)
    {
        _inventoryList.RemoveAt(slotID);

        OnItemRemoved?.Invoke(slotID);
    }
    private ItemModel GetRandomItem()
    {
        var randomIndex = UnityEngine.Random.Range(0, _avaliableItems.Count);
        var randomItem = _avaliableItems[randomIndex];

        return randomItem;
    }
    public List<ItemModel> InventoryList => _inventoryList;
}
