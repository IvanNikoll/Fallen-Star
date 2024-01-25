using System;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public GameObject BackGroundPrefab;
    public GameObject BackGroundTrigger;
    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;
    public GameObject ObstacleSpawner;
    public LevelUIController uIController;
    public CoroutineRunner CoroutineRunnerPrefab;
    public FloatingJoystick joystickPrefab;
    

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameFlowController>().AsSingle().NonLazy();
        InstallBackground();
        InstallFactories();
        InstallInput();
        InstallCamera();
        InstallUI();
    }

    private void InstallUI()
    {
        Container.BindInterfacesAndSelfTo<LevelUIController>().FromComponentInNewPrefab(uIController).AsSingle().NonLazy();
    }

    private void InstallBackground()
    {
        Container.BindInterfacesAndSelfTo<CoroutineRunner>().FromComponentInNewPrefab(CoroutineRunnerPrefab).AsSingle();
        Container.Bind<BackGroundTrigger>().FromComponentInNewPrefab(BackGroundTrigger).AsSingle();
        Container.BindInterfacesAndSelfTo<BackGroundController>().AsSingle().NonLazy();
        Container.BindInstance<GameObject>(BackGroundPrefab).AsSingle().NonLazy();
    }

    private void InstallFactories()
    {
        Container.Bind<ObstacleSpawner>().FromComponentInNewPrefab(ObstacleSpawner).AsSingle().NonLazy();
    }

    private void InstallInput()
    {
        Container.BindInterfacesAndSelfTo<FloatingJoystick>().FromComponentInHierarchy(GameObject.Find("Floating Joystick")).AsSingle(); //.FromComponentInNewPrefab(joystickPrefab).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerView>().FromComponentInNewPrefab(PlayerPrefab).AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerMover>().AsSingle().NonLazy();
        Container.Bind<InputSwitcher>().AsSingle().NonLazy();
    }

    private void InstallCamera()
    {
        Container.Bind<SceneCamera>().FromComponentInNewPrefab(CameraPrefab).AsSingle().NonLazy();
    }
}