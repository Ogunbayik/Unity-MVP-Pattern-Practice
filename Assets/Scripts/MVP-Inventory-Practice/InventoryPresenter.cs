using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryPresenter : IInitializable, IDisposable
{
    private readonly InventoryModel _model;
    private readonly IInventoryView _view;
    private readonly InventroySlot.Factory _slotFactory;
    private readonly SignalBus _signalBus;

    public InventoryPresenter(InventoryModel model, IInventoryView view, InventroySlot.Factory factory, SignalBus signalBus)
    {
        _model = model;
        _view = view;
        _slotFactory = factory;
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _view.OnClickedTakeButton += View_OnClickedTakeButton;
        _model.OnItemAdded += Model_OnItemAdded;
        _model.OnInventoryFulled += Model_OnInventoryFulled;
        _signalBus.Subscribe<GameSignal.RemoveSlotSignal>(RemoveSlot);
        _model.OnItemRemoved += _model_OnItemRemoved;
    }
    private void _model_OnItemRemoved(int slotID)
    {
        _view.RemoveSlot(slotID);
        _view.ReSlotID();
    }

    public void Dispose()
    {
        _view.OnClickedTakeButton -= View_OnClickedTakeButton;
        _model.OnItemAdded -= Model_OnItemAdded;
        _model.OnInventoryFulled -= Model_OnInventoryFulled;
        _signalBus.Unsubscribe<GameSignal.RemoveSlotSignal>(RemoveSlot);
    }
    public void RemoveSlot(GameSignal.RemoveSlotSignal signal) => _model.RemoveItem(signal.SlotID);
    private void View_OnClickedTakeButton() => _model.TryAddRandomItem();
    private void Model_OnItemAdded(ItemModel item)
    {
        var newSlot = _slotFactory.Create();
        newSlot.transform.SetParent(_view.InventoryContainer);
        newSlot.SetupSlot(item.ItemName, _model.InventoryList.Count - 1);

        _view.AddSlot(newSlot);
    }
    private void Model_OnInventoryFulled() => Debug.Log("Inventory is FULLED!");



}
