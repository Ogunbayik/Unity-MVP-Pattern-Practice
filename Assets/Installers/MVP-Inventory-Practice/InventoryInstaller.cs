using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private GameObject _slotPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameSignal.RemoveSlotSignal>();

        Container.Bind<InventoryModel>().AsSingle();

        Container.Bind<IInventoryView>().To<InventoryView>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<InventoryPresenter>().AsSingle().NonLazy();

        Container.BindFactory<InventroySlot, InventroySlot.Factory>()
            .FromComponentInNewPrefab(_slotPrefab)
            .AsSingle();
    }
}