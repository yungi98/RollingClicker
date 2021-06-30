using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("GameManager");

                    instance = container.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/MyDataText.txt";
        playerData = new PlayerData();

        Load();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public PlayerData playerData;
    string filePath;
    string Jdata;

    void Save()
    {
        Jdata = JsonUtility.ToJson(playerData, true);

        byte[] bytes = Encoding.UTF8.GetBytes(Jdata);
        string code = Convert.ToBase64String(bytes);

        File.WriteAllText(filePath, code);
    }

    void Load()
    {
        if(!File.Exists(filePath))
        {
            return;
        }
        string code = File.ReadAllText(filePath);
        byte[] bytes = Convert.FromBase64String(code);
        Jdata = Encoding.UTF8.GetString(bytes);

        playerData = JsonUtility.FromJson<PlayerData>(Jdata);
    }

    public void ResetData()
    {
        PlayerData pd = new PlayerData();

        playerData = pd;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationFocus(bool focus)
    {
        Save();
    }
    private void OnApplicationPause(bool pause)
    {
        Save();
    }
}

