using UnityEngine;

public static class DataSaver
{
    public static void Save(string key, PlayerData data)
    {
        string dataToSave = JsonUtility.ToJson(data, true);
        PlayerPrefs.SetString(key, dataToSave);
    }

    public static PlayerData Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string dataToLoad = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<PlayerData>(dataToLoad);
        }
        else
            return null;

    }
}
