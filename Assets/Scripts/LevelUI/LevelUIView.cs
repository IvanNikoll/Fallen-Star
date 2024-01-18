using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI FinalScoreText;
    [SerializeField] private GameObject FinalScorePanel;
    [Inject] private LevelUIController _uIController;
    private bool _isGameOver;

    private void Start()
    {
        _uIController.OnGameScoreCalculated += ShowFinalScore;
    }

    private void FixedUpdate()
    {
        ScoreText.SetText("Score: " + _uIController.Score);
        if (_isGameOver)
        {
            FinalScoreText.SetText(_uIController.FinalScore.ToString());
        }
    }

    private void ShowFinalScore()
    {
        _isGameOver = true;
        FinalScorePanel.SetActive(true);
    }

    public void PressButton(int buttonID)
    {
        if(buttonID == 1)
        {
            _uIController.RewardPressed();
        }
        if(buttonID == 2)
        {
            _uIController.SaveProgress();
            SceneManager.LoadScene(1);
        }
        if(buttonID == 3)
        {
            _uIController.SaveProgress();
            SceneManager.LoadScene(0);
        }
    }
}