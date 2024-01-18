using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoroutineRunner : MonoBehaviour, IInputChecker
{
    public List<BackGroundMover> Movers;
    private Coroutine _movingCoroutine;
    public event Action OnSpeedChanged;
    public float _speed { get; private set; }
    private bool _isGameOver;

    [Inject]
    private void Construct(GameFlowController gameFlowController)
    {
        gameFlowController.OnGameOver += GameOver;
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        _isGameOver = true;
    }

    private void Start()
    {
        _isGameOver = false;
        _speed = 0.01f;
        Movers = new List<BackGroundMover>();
    }

    public void StartMovingCoroutine(List<GameObject> BackGround)
    {
        if(_movingCoroutine != null)
        {
            StopCoroutine(_movingCoroutine);
            Movers.Clear();
        }
       
        foreach (GameObject go in BackGround) 
        {
            if (go.GetComponent<BackGroundMover>() != null)
            {
                BackGroundMover mover = go.GetComponent<BackGroundMover>();
                Movers.Add(mover);
            }
        }
        _movingCoroutine = StartCoroutine(MovingCoroutine(Movers));
    }

    private IEnumerator MovingCoroutine(List<BackGroundMover> movers)
    {
        while (!_isGameOver)
        {
            foreach (var m in movers)
            {
                m.Move(_speed);
            }
            if (_speed <= 0.2f)
            {
                _speed += 0.0001f;
            }
            OnSpeedChanged?.Invoke();
            yield return new WaitForSeconds(0.02f);
        }
    }
    
    public void StartInputChecker(IInput input)
    {
        IInput playerInput = input;
        StartCoroutine(InputCheckerCoroutine(playerInput));
    }

    private IEnumerator InputCheckerCoroutine(IInput playerInput)
    {
        while (!_isGameOver)
        {
            playerInput.ProcessInput();
            yield return new WaitForSeconds(0.04f);
        }
    }
}