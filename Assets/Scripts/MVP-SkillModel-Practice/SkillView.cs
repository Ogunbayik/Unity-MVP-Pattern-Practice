using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour, ISkillView
{
    [Header("UI Settings")]
    [SerializeField] private Button _skillButton;
    [SerializeField] private Image _skillFillImage;
    [SerializeField] private TextMeshProUGUI _skillCooldownText;

    public event Action OnClickSkillButton;
    private void Start() => _skillButton.onClick.AddListener(() => OnClickSkillButton?.Invoke());

    public void SetButtonEnable(bool isEnable) => _skillButton.enabled = isEnable; 
    public void ToggleCooldownText(bool isActive) => _skillCooldownText.gameObject.SetActive(isActive);
    public void UpdateCooldownText(float cooldown) => _skillCooldownText.text = cooldown.ToString("F1");
    public void UpdateFillAmount(float fillAmount) => _skillFillImage.fillAmount = fillAmount;
    public void SetSelectedColorAlpha(float amount)
    {
        ColorBlock cb = _skillButton.colors;
        Color tempColor = cb.selectedColor;
        tempColor.a = amount;
        cb.normalColor = tempColor;
        _skillButton.colors = cb;
    }
    
}
