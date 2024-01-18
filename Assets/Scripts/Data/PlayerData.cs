using System;

[Serializable]
public class PlayerData
{
    public string Key;
    public int UpgradeLevel;
    public int UpgradePrice;
    public int Credits;
    public float MovingSpeed;

    public PlayerData(string key, int upgradeLevel, int upgradePrice, int credits, float movingSpeed)
    {
        Key= key;
        UpgradeLevel = upgradeLevel;
        UpgradePrice = upgradePrice;
        Credits = credits;
        MovingSpeed = movingSpeed;
    }
}