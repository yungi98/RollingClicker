using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldText;
    public Text countText;

    GameManager GMD;
    void Start()
    {
        GMD = GameManager.Instance;
    }

    void Update()
    {
        goldText.text = "µ· : " + CommaText(GMD.playerData.gold) + "¿ø";
        if (GMD.playerData.gold == 0)
        {
            goldText.text = "µ· : " + 0 + "¿ø";
        }
        countText.text = GMD.playerData.count.ToString();
    }

    public string CommaText(long data)
    {
        return string.Format("{0:#,###}", data);
    }
}
