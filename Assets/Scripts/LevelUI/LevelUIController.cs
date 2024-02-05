using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class LevelUIController : MonoBehaviour
{
    [Inject] private GameFlowController _gameFlowController;
    [Inject] private IPlayerMover _playerMover;
    public event Action OnGameScoreCalculated;
    public int Score { get; private set; }
    public int FinalScore { get; private set; }
    private bool _isGameOver = false;
    private float _timeReward;

    private void Start()
    {
        _timeReward = 1;
        StartCoroutine(ScoreCounter());
        _gameFlowController.OnGameOver += StopTheGame;
        CheckSaves();
    }

    public void StopTheGame()
    {
        _isGameOver = true;
        StartCoroutine(GameOverCoroutine());
    }

    public void SaveProgress()
    {
        PlayerData playerData = DataSaver.Load("StatsSave");
        if (playerData != null)
        {
            int credits = playerData.Credits + Score;
            playerData = new PlayerData("StatsSave", playerData.UpgradeLevel, playerData.UpgradePrice, credits, _playerMover.GetSpeed());
            DataSaver.Save("StatsSave", playerData);
        }
        else
        {
            PlayerData newPlayerData = new PlayerData("StatsSave", 1, 100, Score, _playerMover.GetSpeed());
            DataSaver.Save("StatsSave", newPlayerData);
        }
    }

        public void RewardPressed()
    {
        Debug.Log("Reward watched");
    }

    private void CheckSaves()
    {
        PlayerData playerData = DataSaver.Load("StatsSave");
        if (playerData != null)
        {
            _playerMover.SetSpeed(playerData.MovingSpeed);
        }      
    }

    private IEnumerator ScoreCounter()
    {
        while (!_isGameOver)
        {
            Score++;
            yield return new WaitForSeconds(_timeReward);
        }
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(2);
        OnGameScoreCalculated?.Invoke();
        for (int i = 0; i <= Score; i++)
        {
            FinalScore = i;
            yield return new WaitForSeconds(0.015f);
        }
    }
}