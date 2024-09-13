using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseHandler>().AsSingle();
    }
}
