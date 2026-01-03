using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LampModel 
{
    private bool _isNightMode;

    public LampModel(bool isNightMode = false)
    {
        _isNightMode = isNightMode;
    }
    public bool IsNightMode => _isNightMode;
    public void SetNightMode(bool isNight) => _isNightMode = isNight;
}
