using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn Data", menuName = "ScriptableObject/Spawn Data")]
public class SpawnDataSO : ScriptableObject
{
    [Header("Spawn Settings")]
    [SerializeField] private float _minXRange;
    [SerializeField] private float _maxXRange;
    [SerializeField] private float _minZRange;
    [SerializeField] private float _maxZRange;
    [SerializeField] private int _maxSpawnCount;

    public float MinXRange => _minXRange;
    public float MaxXRange => _maxXRange;
    public float MinZRange => _minZRange;
    public float MaxZRange => _maxZRange;
    public int MaxSpawnCount => _maxSpawnCount;
}
