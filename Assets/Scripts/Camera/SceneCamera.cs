using Cinemachine;
using UnityEngine;
using Zenject;

public class SceneCamera : MonoBehaviour
{
    public PlayerView _view;
    public CinemachineVirtualCamera _camera;

    [Inject]
    public void Construct(PlayerView view)
    {
        _view= view;
    }

    private void Start()
    {
        _camera = this.gameObject.GetComponent<CinemachineVirtualCamera>();
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        _camera.Follow = _view.transform;
    }
}