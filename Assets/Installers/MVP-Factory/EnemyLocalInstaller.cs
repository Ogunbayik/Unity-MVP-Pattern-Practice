using UnityEngine;
using Zenject;

public class EnemyLocalInstaller : MonoInstaller
{
    [Header("Data Settings")]
    [SerializeField] private EnemyDataSO _dataSO;
    public override void InstallBindings()
    {
        Container.BindInstance(_dataSO).AsSingle();
        Container.Bind<EnemyModel>().AsSingle();

        Container.BindInterfacesAndSelfTo<EnemyPresenter>().AsSingle().NonLazy();

        Container.Bind<IEnemyView>().To<EnemyView>().FromComponentInHierarchy().AsSingle();
    }
}