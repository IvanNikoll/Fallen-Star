using UnityEngine;

public class PlayerMover: IPlayerMover
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

    public float GetSpeed()
    {
        return _movingSpeed;
    }

    public void SetSpeed(float speed)
    {
        _movingSpeed = speed;
        Debug.Log("Speed changed to: " + speed);
    }
}