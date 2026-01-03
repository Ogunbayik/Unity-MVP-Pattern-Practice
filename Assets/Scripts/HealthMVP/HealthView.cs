using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IHealthView
{
    [Header("UI Settings")]
    [SerializeField] private Button _damageButton;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private GameObject _gameOverPanel;

    public event Action OnClickDamageButton;

    private void Start() => _damageButton.onClick.AddListener(() => OnClickDamageButton?.Invoke());
    public void UpdateHealthText(int health) => _healthText.text = $"Health: {health.ToString()}";
    public void ToggleGameOverPanel(bool isActive) => _gameOverPanel.SetActive(isActive); 
}
