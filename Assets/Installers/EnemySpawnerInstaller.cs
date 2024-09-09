using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
