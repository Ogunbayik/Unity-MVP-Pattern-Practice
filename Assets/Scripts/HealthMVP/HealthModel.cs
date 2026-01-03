using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModel 
{
    private HealthDataSO _dataSO;

    private int _currentHealth;

    public event Action<int> OnHealthChanged;
    public event Action OnDead;
    public HealthModel(HealthDataSO dataSO)
    {
        _dataSO = dataSO;
        _currentHealth = _dataSO.MaxHealth;
    }
    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDead?.Invoke();
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }
    public int CurrentHealth => _currentHealth;
}
