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

    private float GetRandomTime(float minTime, float maxTime)
    {
        float respawnTime = Random.Range(minTime, maxTime);
        return respawnTime;
    }
    
    private IEnumerator SpawningCoroutine()
    {
        float minSpawnTime = 3;
        float maxSpawnTime = 5;
        while (!_isGameOver)
        {
            float respawnTime = GetRandomTime(minSpawnTime,maxSpawnTime);
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