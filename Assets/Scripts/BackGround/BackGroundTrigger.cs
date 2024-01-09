using System;
using UnityEngine;

public class BackGroundTrigger : MonoBehaviour
{
    public event Action<GameObject> BackGroundReachedBoundary;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BackGroundMover>() != null)
        {
            BackGroundReachedBoundary?.Invoke(other.gameObject);
        }
    }
}