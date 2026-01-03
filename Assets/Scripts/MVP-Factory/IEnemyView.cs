using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyView 
{
    public event Action OnEnemyHitted;
    void UpdateHealthFillAmount(float amount);
    void SelfDestroy();
}
