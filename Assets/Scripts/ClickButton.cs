using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public GameObject cvs;
    
    GameManager GMD;

    void Start()
    {
        GMD = GameManager.Instance;
    }

    public void OnClick()
    {
        if(GMD.playerData.count <= 1)
        {
            GMD.playerData.count += GMD.playerData.saveCount;
            GMD.playerData.gold += 10000;
        }
        GMD.playerData.count -= 1;
        cvs.GetComponent<ClickDelayBar>().Delay();
    }
}
