using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    [Header("Data Settings")]
    [SerializeField] private HealthDataSO _healthData;
    public override void InstallBindings()
    {
        Container.Bind<HealthModel>().AsSingle();

        Container.BindInstance(_healthData).AsSingle();

        Container.Bind<IHealthView>().To<HealthView>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<HealthPresenter>().AsSingle().NonLazy();
    }
}