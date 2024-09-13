using UnityEngine;
using Zenject;

public class FirstExampleInstaller : MonoInstaller
{
    [SerializeField] private HUDLayer _hudLayer;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<MovementHandler>().AsSingle();

        Container.Bind<HUDLayer>().FromInstance(_hudLayer).AsSingle();

        if (SystemInfo.deviceType == DeviceType.Handheld)
            Container.BindInterfacesAndSelfTo<Joystick>().FromFactory<Joystick, JoystickFacotry>().AsSingle().NonLazy();
    }
}

public class JoystickFacotry : IFactory<Joystick>
{
    private const string JoystickPrefabPath = "Joystick";
    private IInstantiator _instantiator;
    private HUDLayer _parent;

    public JoystickFacotry(IInstantiator instantiator, HUDLayer parent)
    {
        _instantiator = instantiator;
        _parent = parent;
    }

    public Joystick Create()
    {
        Joystick joystickPrefab = Resources.Load<Joystick>(JoystickPrefabPath);

        return _instantiator.InstantiatePrefabForComponent<Joystick>(joystickPrefab, _parent.transform);
    }
}

