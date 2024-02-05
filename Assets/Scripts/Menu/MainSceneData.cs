using System;
using UnityEngine;

public class MainSceneData
{
    public event Action OnUpgrade;
    public int UpgradeLevel { get; private set; }
    public int UpgradePrice { get; private set; }
    public int Credits { get; private set; }
    private float _movingSpeed;

    public MainSceneData()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerData playerData = new PlayerData("StatsSave", UpgradeLevel, UpgradePrice, Credits, _movingSpeed);
        DataSaver.Save("StatsSave", playerData);
    }

    public void UpgradeSpeed()
    {
        if (Credits >= UpgradePrice)
        {
            Credits -= UpgradePrice;
            UpgradeLevel++;
            UpgradePrice *= 2;
            _movingSpeed += 0.005f;
            SaveData();
            OnUpgrade?.Invoke();
        }
    }

    private void LoadData()
    {
        LoadStatsData();
    }

    private void LoadStatsData()
    {
        PlayerData playerData = DataSaver.Load("StatsSave");
        if (playerData != null)
        {
            UpgradeLevel = playerData.UpgradeLevel;
            UpgradePrice = playerData.UpgradePrice;
            Credits = playerData.Credits;
            _movingSpeed = playerData.MovingSpeed;
        }
        else 
        {
            Debug.Log("Stats not found. Load Default");
            _movingSpeed = 0.005f;
            UpgradeLevel = 1;
            UpgradePrice = 100;
            Credits = 0;
        } 
    }
}