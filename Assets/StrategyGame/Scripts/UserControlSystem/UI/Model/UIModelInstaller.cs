using UnityEngine;
using Zenject;

public class UIModelInstaller : MonoInstaller
{
    [SerializeField] private Sprite _cubikSprite;

    public override void InstallBindings()
    {
        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCommandCreator>().AsTransient();

        Container.Bind<CommandButtonsModel>().AsTransient();

        Container.Bind<float>().WithId("Cubik").FromInstance(5f);
        Container.Bind<string>().WithId("Cubik").FromInstance("Cubik");
        Container.Bind<Sprite>().WithId("Cubik").FromInstance(_cubikSprite);

        Container.Bind<BottomCenterModel>().AsTransient();
    }
}
