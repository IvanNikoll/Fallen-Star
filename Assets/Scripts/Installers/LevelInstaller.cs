using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public GameObject BackGroundPrefab;
    public GameObject BackGroundTrigger;
    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;
    public CoroutineRunner CoroutineRunnerPrefab;

    public override void InstallBindings()
    {
        InstallBackground();
        InstallInput();
        InstallCamera();
    }

    private void InstallBackground()
    {
        Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromComponentInNewPrefab(CoroutineRunnerPrefab).AsSingle();
        Container.Bind<BackGroundTrigger>().FromComponentInNewPrefab(BackGroundTrigger).AsSingle();
        Container.BindInterfacesAndSelfTo<BackGroundController>().AsSingle().NonLazy();
        Container.BindInstance<GameObject>(BackGroundPrefab).AsSingle().NonLazy();
    }

    private void InstallInput()
    {
        Container.BindInterfacesAndSelfTo<PlayerView>().FromComponentInNewPrefab(PlayerPrefab).AsSingle();
        Container.Bind<PlayerMover>().AsSingle().NonLazy();
        Container.Bind<InputSwitcher>().AsSingle().NonLazy();
    }

    private void InstallCamera()
    {
        Container.Bind<SceneCamera>().FromComponentInNewPrefab(CameraPrefab).AsSingle().NonLazy();
    }
}