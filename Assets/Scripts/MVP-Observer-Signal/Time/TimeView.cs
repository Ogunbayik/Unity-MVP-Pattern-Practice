using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimeView : MonoBehaviour, ITimeView
{
    [Header("Light Settings")]
    [SerializeField] private Light _directionalLight;
    [Header("UI Settings")]
    [SerializeField] private Button _switchButton;
    [SerializeField] private TextMeshProUGUI _dayText;

    public event Action OnClickedSwitchButton;
    void Start() => _switchButton.onClick.AddListener(() => OnClickedSwitchButton?.Invoke());

    public void UpdateDayText(string day) => _dayText.text = day;
    public void SetDirectionLightRotation(Vector3 rotation) => _directionalLight.transform.rotation = Quaternion.Euler(rotation);

}
