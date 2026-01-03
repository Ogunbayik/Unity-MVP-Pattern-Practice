using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeView 
{
    public event Action OnClickedSwitchButton;
    void UpdateDayText(string day);
    void SetDirectionLightRotation(Vector3 rotation);
}
