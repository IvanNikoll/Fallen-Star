using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class MainMenuBtn : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject QuitConfirmationPanel;
    [SerializeField] private Text CreditsText;
    [SerializeField] private Text LevelText;
    [SerializeField] private Text UpgradePriceText;
    [Inject] private MainSceneData _sceneData;

    public void Start()
    {
        _sceneData.OnUpgrade += UpdateShop;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(1);
        Destroy(GameObject.Find("Audio Source"));
    }

    public void OpenShop()
    {
        UpdateShop();
        MainPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }

    public void UpgradeSpeed()
    {
        _sceneData.UpgradeSpeed();
    }

    public void QuitGame()
    {
        QuitConfirmationPanel.SetActive(true);
    }

    public void CloseBtn()
    {
        QuitConfirmationPanel.SetActive(false);
        ShopPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    private void UpdateShop()
    {
        CreditsText.text = "Credits: " + _sceneData.Credits.ToString();
        LevelText.text = "Level " + _sceneData.UpgradeLevel;
        UpgradePriceText.text = "Upgrade price: " + _sceneData.UpgradePrice;
    }
}