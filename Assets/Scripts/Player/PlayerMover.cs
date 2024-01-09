using UnityEngine;

public class PlayerMover
{
    private float _movingSpeed;
    public Transform PlayerTransform { get; private set; }

    public PlayerMover(PlayerView view)
    {
        PlayerTransform = view.gameObject.transform;
        _movingSpeed = 0.1f;
    }

    public void Move(Vector3 directionVector)
    {
        PlayerTransform.Translate(directionVector * _movingSpeed);
    }
}