using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeModel 
{
    private string _dayStatus;
    private bool _isNight;

    private Vector3 _currentLightRotation;

    public TimeModel(bool isNight = false)
    {
        _isNight = isNight;
        _dayStatus = GameConstant.DayConst.DAY;
        _currentLightRotation = GameConstant.DayConst.DAY_ROTATION;
    }
    public void ToggleDayNight()
    {
        _isNight = !_isNight;
        _dayStatus = _isNight ? GameConstant.DayConst.NIGHT : GameConstant.DayConst.DAY;
    }
    public Vector3 CurrentLightRotation => _isNight ? GameConstant.DayConst.NIGHT_ROTATION : GameConstant.DayConst.DAY_ROTATION;
    public bool IsNight => _isNight;
    public string DayStatus => _dayStatus;
}
