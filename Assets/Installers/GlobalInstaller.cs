using System;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    private const string CoroutinePerformerPath = "CoroutinePerformer";

    public override void InstallBindings()
    {
        BindInput();
        BindLoader();
        BindWallet();
        BindCoroutinePerformer();
    }

    private void BindCoroutinePerformer()
    {
        Container
            .Bind<ICoroutinePerformer>()
            .To<CoroutinePerformer>()
            .FromComponentInNewPrefabResource(CoroutinePerformerPath)
            .AsSingle()
            .NonLazy();
    }

    private void BindWallet()
    {
        //Wallet wallet = new Wallet(1000);
        //Container.BindInstance(wallet).AsSingle();
        Container.BindInterfacesAndSelfTo<Wallet>().AsSingle().WithArguments(1000);
    }

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesTo<SceneLoader>().AsSingle();   
        Container.Bind<SceneLoadMediator>().AsSingle();
    }

    private void BindInput()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
            Container.BindInterfacesTo<MobileInput>().AsSingle();
        else
            Container.BindInterfacesTo<DesktopInput>().AsSingle();
    }
}
