using UnityEngine;

public class BackGroundMover : MonoBehaviour, IMover
{
    private float _speed;

    public void Move(float speed)
    {
        _speed = speed;
        transform.Translate(new Vector3(_speed,0, 0));
    }

    public void ResetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}