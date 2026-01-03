using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthView
{
    public event Action OnClickDamageButton;
    void UpdateHealthText(int health);
    void ToggleGameOverPanel(bool isActive);
}
