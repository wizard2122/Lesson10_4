using Zenject;

public class FirstExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<MovementHandler>().AsSingle();
    }
}
