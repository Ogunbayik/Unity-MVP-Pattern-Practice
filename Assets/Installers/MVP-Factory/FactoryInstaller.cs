using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private SpawnDataSO _spawnData;
    public override void InstallBindings()
    {
        Container.BindInstance(_spawnData).AsSingle();

        Container.BindFactory<EnemyView, EnemyView.Factory>()
            .FromComponentInNewPrefab(_enemyPrefab)
            .AsTransient();
    }
}