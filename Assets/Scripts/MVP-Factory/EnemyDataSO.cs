using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName ="ScriptableObject/Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField] private int _minimumHealth;
    [SerializeField] private int _maximumHealth;

    public int MinimumHealth => _minimumHealth;
    public int MaximumHealth => _maximumHealth;
}
