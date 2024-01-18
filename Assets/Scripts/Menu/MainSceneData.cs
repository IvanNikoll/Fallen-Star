using System;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneData
{
    public event Action OnUpgrade;
    public int UpgradeLevel { get; private set; }
    public int UpgradePrice { get; private set; }
    public int Credits { get; private set; }
    private List<PlayerData> _statsdataList;
    private float _movingSpeed;

    public MainSceneData()
    {
        _statsdataList = new List<PlayerData>();
        LoadData();
    }

    public void SaveData()
    {
        _statsdataList.Clear();
        _statsdataList.Add(new PlayerData("StatsSave", UpgradeLevel, UpgradePrice, Credits, _movingSpeed));
        DataSaver.Save(_statsdataList, "StatsSave");
    }

    public void UpgradeSpeed()
    {
        if (Credits >= UpgradePrice)
        {
            Credits -= UpgradePrice;
            UpgradeLevel++;
            UpgradePrice *= 2;
            _movingSpeed += 1;
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
        _statsdataList = DataSaver.ReadFromJSON<PlayerData>("StatsSave");
        PlayerData playerData = _statsdataList.Find(note => note.Key == "StatsSave");
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
            _movingSpeed = 0.1f;
            UpgradeLevel = 1;
            UpgradePrice = 100;
            Credits = 0;
        } 
    }
}