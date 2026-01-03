using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel 
{
    private EnemyDataSO _data;

    private int _currentHealth;
    private int _initialHealth;

    public event Action<int> OnEnemyHealthChanged;
    public event Action OnEnemyDead;
    public EnemyModel(EnemyDataSO data)
    {
        _data = data;
        _initialHealth = GetRandomHealth();
        _currentHealth = _initialHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnEnemyDead?.Invoke();
        }

        OnEnemyHealthChanged?.Invoke(_currentHealth);
    }
    private int GetRandomHealth() => UnityEngine.Random.Range(_data.MinimumHealth, _data.MaximumHealth);

    public EnemyDataSO Data => _data;
    public int InitialHealth => _initialHealth;
}
