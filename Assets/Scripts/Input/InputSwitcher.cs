using UnityEngine;
using Zenject;

public class InputSwitcher
{
    private DiContainer _container;
    private PlayerMover _mover;
    private IInputChecker _checker;

    [Inject]
    public void Construct(DiContainer container, PlayerMover mover, IInputChecker checker)
    {
        _container = container;
        _mover = mover;
        _checker = checker;
        SwitchPlatform();
    }

    private void SwitchPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                SwitchInputForAndroid();
                break;
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                SwitchInputForDesktop();
                break;
            default:
                Debug.Log("Unsupported platform");
                break;
        }
    }

    private void SwitchInputForAndroid()
    {
        // Логика для Android
    }

    private void SwitchInputForDesktop()
    {
        _container.BindInterfacesAndSelfTo<PlayerInput>().FromInstance(new DesktopInput(_mover, _checker)).AsSingle().NonLazy();
    }
}