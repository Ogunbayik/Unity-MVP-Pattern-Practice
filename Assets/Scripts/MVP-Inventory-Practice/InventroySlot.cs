using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventroySlot : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    [SerializeField] private TextMeshProUGUI slotText;
    [SerializeField] private Button _deleteButton;

    private int _slotID;

    private void Start() => _deleteButton.onClick.AddListener(() => _signalBus.Fire(new GameSignal.RemoveSlotSignal(_slotID)));
    public void SetupSlot(string itemName, int slotID)
    {
        slotText.text = itemName;
        _slotID = slotID;
    }
    public void ReSlotID(int slotID) => _slotID = slotID;

    public class Factory : PlaceholderFactory<InventroySlot> { }
}
