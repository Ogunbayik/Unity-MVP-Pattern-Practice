using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillView
{
    public event Action OnClickSkillButton;

    void SetButtonEnable(bool isEnable);
    void ToggleCooldownText(bool isActive);
    void UpdateCooldownText(float cooldown);
    void UpdateFillAmount(float fillAmount);
    void SetSelectedColorAlpha(float amount);
}
