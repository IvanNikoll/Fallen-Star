using UnityEngine;

public class SceneCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BackGroundMover>() == null)
        {
            Destroy(other.gameObject);
        }
    }
}