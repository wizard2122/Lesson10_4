using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    private const string PlayePrefabPath = "Player";

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
        Container.BindInterfacesAndSelfTo<Player>().FromComponentInNewPrefabResource(PlayePrefabPath).AsSingle().NonLazy();

        //Container.BindInterfacesAndSelfTo<Player>().FromFactory<Player, PlayerFactory>().AsSingle().OnInstantiated<Player>(OnPlayerInstantiated).NonLazy();
    }

    //private void OnPlayerInstantiated(InjectContext arg1, Player player)
    //{
    //    player.transform.position = _playerSpawnPoint.position;
    //}

    private void BindConfig()
        => Container.Bind<PlayerStatsConfig>().FromInstance(_playerStatsConfig).AsSingle();
}
