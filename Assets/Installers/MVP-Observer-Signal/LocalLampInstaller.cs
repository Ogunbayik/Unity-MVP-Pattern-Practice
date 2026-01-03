using UnityEngine;
using Zenject;

public class LocalLampInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LampModel>().AsSingle();

        Container.BindInterfacesAndSelfTo<LampView>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<LampPresenter>().AsSingle().NonLazy();
    }
}