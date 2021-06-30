using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DUpgradeButton : MonoBehaviour
{
    public Text upgradeText;

    public string upgradeName;

    GameManager GMD;
    void Start()
    {
        GMD = GameManager.Instance;
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (GMD.playerData.gold >= GMD.playerData.DgoldByUpgrade && GMD.playerData.clickDelayCount != 1)
        {
            GMD.playerData.gold -= GMD.playerData.DgoldByUpgrade;
            GMD.playerData.clickDelayCount -= 1;
            GMD.playerData.clickDelay -= 0.01f;
            GMD.playerData.clickDelay = Mathf.Floor(GMD.playerData.clickDelay * 100) / 100;

            UpdateUpgrade();
        }
    }

    public void UpdateUpgrade()
    {
        SubNum();
        GMD.playerData.DgoldByUpgrade = GMD.playerData.DgoldByUpgrade + GMD.playerData.DupgradeNum;
        
        UpdateUI();
    }

    public void SubNum()
    {
        switch(100- GMD.playerData.clickDelayCount)
        {
            case 10: GMD.playerData.DupgradeNum = 2000;   break;
            case 20: GMD.playerData.DupgradeNum = 5000;   break;
            case 40: GMD.playerData.DupgradeNum = 7000;   break;
            case 50: GMD.playerData.DupgradeNum = 10000;   break;
            case 60: GMD.playerData.DupgradeNum = 20000;   break;
            case 70: GMD.playerData.DupgradeNum = 50000;   break;
            case 80: GMD.playerData.DupgradeNum = 100000;   break;
            case 90: GMD.playerData.DupgradeNum = 500000;   break;
            case 96: GMD.playerData.DupgradeNum = 2000000;   break;
            case 97: GMD.playerData.DupgradeNum = 3000000;   break;
            case 98: GMD.playerData.DupgradeNum = 10000000;   break;
            default: break;
        }
    }

    public void UpdateUI()
    {
        upgradeText.text = upgradeName + "\n필요한 돈 : " + CommaText(GMD.playerData.DgoldByUpgrade) + "\n일의 속도 : " + GMD.playerData.clickDelay;
        if(GMD.playerData.clickDelayCount <= 1)
        {
            upgradeText.text = "<size=40><color=While><b>MAX</b></color></size>" + "\n일의 속도 : " + GMD.playerData.clickDelay;
        }
    }
    public string CommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
