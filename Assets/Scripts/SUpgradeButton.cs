using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUpgradeButton : MonoBehaviour
{
    public Text upgradeText;

    public string upgradeName;

    public int goldByUpgrade = 1; //업그레이드를 위해 필요한 돈
    public int upgradeNum = 1; //업그레이드의 상승량
    

    private DataController DataC()
    {
        return DataController.Instance;
    }

    void Start()
    {
        DataC().LoadSUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (DataC().gold >= goldByUpgrade && DataC().m_clickDlayCount != 1)
        {
            DataC().gold -= goldByUpgrade;
            DataC().m_clickDlayCount -= 1;
            DataC().m_clickDlay -= 0.01f;
            DataC().m_clickDlay = Mathf.Floor(DataC().m_clickDlay * 100) / 100;

            UpdateUpgrade();
            DataC().SaveSUpgradeButton(this);
        }
    }

    public void UpdateUpgrade()
    {
        SubNum();
        goldByUpgrade = goldByUpgrade + upgradeNum;
        
        UpdateUI();
    }

    public void SubNum()
    {
        switch(100-DataC().m_clickDlayCount)
        {
            case 10: upgradeNum = 2;   break;
            case 20: upgradeNum = 5;   break;
            case 40: upgradeNum = 7;   break;
            case 50: upgradeNum = 10;   break;
            case 60: upgradeNum = 20;   break;
            case 70: upgradeNum = 50;   break;
            case 80: upgradeNum = 100;   break;
            case 90: upgradeNum = 500;   break;
            case 96: upgradeNum = 2000;   break;
            case 97: upgradeNum = 3000;   break;
            case 98: upgradeNum = 10000;   break;
            default: break;
        }
    }

    public void UpdateUI()
    {
        upgradeText.text = upgradeName + "\n필요한 돈 : " + goldByUpgrade + "\n일의 속도 : " + DataC().m_clickDlay;
        if(DataC().m_clickDlayCount <= 1)
        {
            upgradeText.text = "<size=20><color=While><b>MAX</b></color></size>" + "\n일의 속도 : " + DataC().m_clickDlay;
        }
    }
}
