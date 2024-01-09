using UnityEngine;

public class PlayerController: MonoBehaviour 
{
    private int _upperBoundary;
    private int _lowerBoundary;
    private int _leftBoundary;
    private int _rightBoundary;

    private void Start()
    {
        _upperBoundary = 10;
        _lowerBoundary = -_upperBoundary;
        _leftBoundary = 28;
        _rightBoundary = 7;
    }
    private void FixedUpdate()
    {
        CheckPlayerPosition();
    }
    private void CheckPlayerPosition()
    {
        Transform player = gameObject.transform;
        if (player.position.y > _upperBoundary)
        {
            player.position = new Vector3(player.position.x, _upperBoundary,3);
        }
        if (player.position.y < _lowerBoundary)
        {
            player.position = new Vector3(player.position.x, _lowerBoundary,3);
        }
        if (player.position.x < _rightBoundary)
        {
            player.position = new Vector3(_rightBoundary, player.position.y,3);
        }
        if (player.position.x > _leftBoundary)
        {
            player.position = new Vector3(_leftBoundary, player.position.y, 3);
        }
    }
}