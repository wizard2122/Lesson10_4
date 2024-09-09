using System;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
        BindLoader();
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
