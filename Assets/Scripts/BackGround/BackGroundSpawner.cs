// Ignore Spelling: registrator
using UnityEngine;

public class BackGroundSpawner : IBackGroundSpawner
{
    private IBackGroundRegistrator _registrator;
    private GameObject _backGroundprefab;
    public BackGroundSpawner(IBackGroundRegistrator registrator, GameObject BackGroundPrefab)
    {
        _registrator = registrator;
        _backGroundprefab = BackGroundPrefab;
        Spawn(new Vector2(3,0));
    }

    public void Spawn(Vector2 spawnPosition)
    {
        GameObject newObject = Object.Instantiate(_backGroundprefab, spawnPosition, Quaternion.identity);
        if(_backGroundprefab.GetComponent<BackGroundMover>() != null)
        {
            _registrator.AddToList(newObject);
        }
    }
}
