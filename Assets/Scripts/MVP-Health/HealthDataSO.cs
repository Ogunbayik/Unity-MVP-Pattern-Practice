using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Data", menuName = "ScriptableObject/Data")]
public class HealthDataSO : ScriptableObject
{
    [Header("Data Settings")]
    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;
}
