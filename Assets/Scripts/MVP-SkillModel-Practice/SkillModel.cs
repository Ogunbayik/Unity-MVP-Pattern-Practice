using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModel
{
    private float _cooldownTime;
    private float _currentTime;
    private bool _isReady;

    public event Action OnSkillReady;
    public SkillModel(bool isReady = true, float cooldownTime = GameConstant.SkillConst.SKILL_COOLDOWN)
    {
        _isReady = isReady;
        _cooldownTime = cooldownTime;
        _currentTime = _cooldownTime;
    }

    public void Tick(float deltaTime)
    {
        if(!_isReady)
        {
            //Clicked Button
            _currentTime -= deltaTime;
            if(_currentTime <= 0)
            {
                _currentTime = _cooldownTime;
                SetReadyStatus(true);
                OnSkillReady?.Invoke();
            }
        }
    }
    public float GetReverseProgress()
    {
        var progress = _currentTime / GameConstant.SkillConst.SKILL_COOLDOWN;
        var reverseProgress = 1f - Mathf.Clamp01(progress);

        return reverseProgress;
    }
    public bool IsReady => _isReady;
    public float CurrentTime => _currentTime;
    public void SetReadyStatus(bool isReady) => _isReady = isReady;
}
