using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSignal.DayNightChangeSignal>();

        Container.Bind<TimeModel>().AsSingle();

        Container.Bind<ITimeView>().To<TimeView>().FromComponentInHierarchy().AsSingle();
       
        Container.BindInterfacesAndSelfTo<TimePresenter>().AsSingle().NonLazy();
    }
}