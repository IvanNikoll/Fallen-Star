using System.Collections;
using UnityEngine;
using Zenject;

public class ObstacleSpawner : MonoBehaviour
{
    [Inject] private CoroutineRunner _coroutineRunner;
    [Inject] private GameFlowController _Controller;
    [SerializeField] private GameObject[] IdlePrefab;   
    private const int YSpawnRange = 10;
    private const int XSpawnValue = -10;
    private bool _isGameOver = false;
    private Vector3 _spawnVector;
    private int _currentPrefab;

    private void Start()
    {
        StartCoroutine(SpawningCoroutine());
        _Controller.OnGameOver += StopSpawner;
    }

    public void Spawn(GameObject gameObject)
    {
        GameObject prefab = Instantiate(gameObject, _spawnVector, Quaternion.identity);
        ISpeedProvider speedProvider = prefab.GetComponent<ISpeedProvider>();
        speedProvider.Initialize(_coroutineRunner._speed);
    }

    private void  GetRandomValues()
    {
        _currentPrefab = Random.Range(0, IdlePrefab.Length);
        float y = Random.Range(YSpawnRange, -YSpawnRange);
        _spawnVector = new Vector3(XSpawnValue,y, 3);
    }

    private float GetRandomTime()
    {
        float respawnTime = Random.Range(4, 6);
        return respawnTime;

    }
    
    private IEnumerator SpawningCoroutine()
    {
        while (!_isGameOver)
        {
            float respawnTime = GetRandomTime();
            GetRandomValues();
            Spawn(IdlePrefab[_currentPrefab]);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    private void StopSpawner()
    {
        _isGameOver = true;
    }
}