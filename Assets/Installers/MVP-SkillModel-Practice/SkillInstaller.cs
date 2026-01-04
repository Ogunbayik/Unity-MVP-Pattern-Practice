using UnityEngine;
using Zenject;

public class SkillInstaller : MonoInstaller
{
    [SerializeField] private Transform _attackTransform;
    [SerializeField] private GameObject _fireballPrefab;
    public override void InstallBindings()
    {
        Container.Bind<SkillModel>().AsSingle();

        Container.Bind<ISkillView>().To<SkillView>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<SkillPresenter>().AsSingle().NonLazy();

        Container.BindInstance(_attackTransform).AsSingle();

        Container.BindFactory<Fireball, Fireball.Factory>()
            .FromComponentInNewPrefab(_fireballPrefab)
            .AsTransient();
    }
}