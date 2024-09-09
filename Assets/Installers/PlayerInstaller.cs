using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    [SerializeField] private PlayerStatsConfig _playerStatsConfig;

    public override void InstallBindings()
    {
        BindConfig();
        BindInstance();
    }

    private void BindInstance()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();
    }

    private void BindConfig()
        => Container.Bind<PlayerStatsConfig>().FromInstance(_playerStatsConfig).AsSingle();


}
