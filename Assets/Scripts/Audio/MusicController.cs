using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
