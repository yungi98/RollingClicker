using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private static DataController instance;

    public static DataController Instance
    {
        get{
            if(instance == null)
            {
                instance = FindObjectOfType<DataController>();

                if(instance == null)
                {
                    GameObject container = new GameObject("DataController");

                    instance = container.AddComponent<DataController>();
                }
            }
            return instance;
        }    
    }

    public long gold
    {
        get
        {
            if(!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string tmpGold = PlayerPrefs.GetString("Gold");
            return long.Parse(tmpGold);
        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    public int m_count
    {
        get
        {
            return PlayerPrefs.GetInt("count", 100);
        }
        set
        {
            PlayerPrefs.SetInt("count", value);
        }
    }

    public int m_saveCount
    {
        get
        {
            return PlayerPrefs.GetInt("saveCount", 100);
        }
        set
        {
            PlayerPrefs.SetInt("saveCount", value);
        }
    }
    
    public float m_clickDlay
    {
        get
        {
            return PlayerPrefs.GetFloat("clickDlay", 1.00f);
        }
        set
        {
            PlayerPrefs.SetFloat("clickDlay", value);
        }
    }

    public int m_clickDlayCount
    {
        get
        {
            return PlayerPrefs.GetInt("clickDlayCount", 92);
        }
        set
        {
            PlayerPrefs.SetInt("clickDlayCount", value);
        }
    }

    void Awake()
    {
       // PlayerPrefs.DeleteAll();
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        upgradeButton.upgradeNum = PlayerPrefs.GetInt(key + "_upgradeNum", upgradeButton.upgradeNum);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_upgradeNum", upgradeButton.upgradeNum);
    }

    public void LoadSUpgradeButton(SUpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        upgradeButton.upgradeNum = PlayerPrefs.GetInt(key + "_upgradeNum", upgradeButton.upgradeNum);
    }

    public void SaveSUpgradeButton(SUpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;

        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_upgradeNum", upgradeButton.upgradeNum);
    }
}
