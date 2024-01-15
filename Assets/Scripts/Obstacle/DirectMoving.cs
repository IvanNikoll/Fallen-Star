using UnityEngine;
using Zenject;

public class DirectMoving : MonoBehaviour, ISpeedProvider, IGameStopper
{
    private Vector3 _movingVector;
    public float _speed;
    private bool _isMoving = true;

    [Inject]
    public void Initialize(float speed)
    {
        _speed = speed;
        _movingVector = Vector3.right;
    }
    private void FixedUpdate()
    {
        IncreaseSpeed();
        Move();
    }
    private void IncreaseSpeed()
    {
        if (_isMoving)
        {
            _speed += 0.0001f;
        }
        else _speed = 0;
    }

    private void Move()
    {
        transform.Translate(_movingVector * _speed);
    }

    public void StopTheGame()
    {
        _isMoving = false;
    }
}
