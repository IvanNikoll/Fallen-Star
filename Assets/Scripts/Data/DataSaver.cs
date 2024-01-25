using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;

public static class DataSaver
{
    public static void Save<T>(List<T> dataToSave, string fileName)
    {
        string context = JSonHelper.ToJSon<T>(dataToSave.ToArray());
        WriteFile(GetPath(fileName), context);
        Debug.Log("Saved to: " + GetPath(fileName));
    }

    public static List<T> ReadFromJSON<T>(string fileName)
    {
        string content = ReadFile(GetPath(fileName));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }
        List<T> data = JSonHelper.FromJSon<T>(content).ToList();
        return data;
    }

    private static string GetPath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
        //return Application.persistentDataPath + "/" + fileName;
    }

    private static void WriteFile(string path, string context)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(context);
        }
    }

    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}
public static class JSonHelper
{
    public static T[] FromJSon<T>(string jSon)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jSon);
        return wrapper.Items;
    }

    public static string ToJSon<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJSon<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
