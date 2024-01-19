using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : IBackGroundRegistrator
{
    private IBackGroundSpawner _spawner;
    private CoroutineRunner _coroutineRunner;
    private List<GameObject> _backGround;
    private Vector3 _backGroundRespawnPosition;

    public BackGroundController(GameObject BackGroundPrefab, CoroutineRunner coroutineRunner, BackGroundTrigger trigger)
    {
        _backGround = new List<GameObject>();
        _coroutineRunner = coroutineRunner;
        _spawner = new BackGroundSpawner(this, BackGroundPrefab);
        _backGroundRespawnPosition = new Vector3(-57f,0,-10);
        trigger.BackGroundReachedBoundary += OnBackGroundReachedBoundary;
    }

    public void AddToList(GameObject backGround)
    {
        _backGround.Add(backGround);
        _coroutineRunner.StartMovingCoroutine(_backGround);
    }

    private void OnBackGroundReachedBoundary(GameObject backGround)
    {
        Debug.Log("Collision");
        if(_backGround.Count < 2 )
        {
            _spawner.Spawn(_backGroundRespawnPosition);
        }
        else 
        {
            foreach (var go in _backGround)
            {
                if(go != backGround)
                {
                    IMover mover = go.gameObject.GetComponent<IMover>();
                    mover.ResetPosition(_backGroundRespawnPosition);
                }
            }
        }
    }
}