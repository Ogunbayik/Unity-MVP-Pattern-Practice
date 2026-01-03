using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private Button _spawnButton;

    private EnemyView.Factory _enemyFactory;

    private SpawnDataSO _data;

    [Inject]
    public void Construct(EnemyView.Factory enemyFactory, SpawnDataSO data)
    {
        _enemyFactory = enemyFactory;
        _data = data;
    }

    private void Start() => _spawnButton.onClick.AddListener(() => SpawnEnemy());

    private void SpawnEnemy()
    {
        var newEnemy = _enemyFactory.Create();
        newEnemy.transform.position = GetRandomSpawnPosition();
        newEnemy.transform.rotation = Quaternion.identity;
    }
    private Vector3 GetRandomSpawnPosition()
    {
        var randomX = UnityEngine.Random.Range(_data.MinXRange, _data.MaxXRange);
        var randomZ = UnityEngine.Random.Range(_data.MinZRange, _data.MaxZRange);
        var randomPosition = new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }
}
