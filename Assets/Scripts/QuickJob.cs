using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickJob : MonoBehaviour
{
    public Button QuickJobButton;
    public Button startButton;
    public GameObject start;
    public Button QJCB;

    public Text clickNumText;
    public int num = 0;
    public Text clickTotalText;
    public Text maxNumText;

    public Text countTimeText;
    public float countTime;
    public bool isEnded;

    GameManager GMD;

    void Awake()
    {
        GMD = GameManager.Instance;
        maxNumText.text = "" + GMD.playerData.maxClickInTimer;
        clickTotalText.text = "" + GMD.playerData.clickTotal;
        startButton.onClick.AddListener(OnStartClickButton);
        QJCB.onClick.AddListener(QJClickButton);
        QJCB.interactable = false;
        isEnded = false;
        start.SetActive(true);
    }

    private void Update()
    {
        if(isEnded == true)
        {
            CountTimer();
        }      
    }
    public void OnStartClickButton()
    {
        start.SetActive(false);
        QuickJobButton.interactable = false;
        QJCB.interactable = true;
        isEnded = true;
        countTime = 10f;
    }

    public void QJClickButton()
    {
        if(countTime > 0)
        {
            num += 1;
            clickNumText.text = "" + num;
            GMD.playerData.clickTotal += 1;
            clickTotalText.text = "" + GMD.playerData.clickTotal;
        }   
    }

    public void CountTimer()
    {
        if (countTime > 0)
        {
            countTime -= Time.deltaTime;
            countTimeText.text = "<color=red>" + Mathf.Ceil(countTime).ToString() + " √ </color>";
        }
        else
        {
            ResetTimer();
        }  
    }

    public void ResetTimer()
    {
        QJCB.interactable = false;
        isEnded = false;
        if(num >= 100)
        {
            GMD.playerData.gold += 1000;
        }
        if(GMD.playerData.maxClickInTimer < num)
        {
            GMD.playerData.maxClickInTimer = num;
            maxNumText.text = "<color=yellow>" + GMD.playerData.maxClickInTimer + "</color>";
        }
        countTime = 10f;
        countTimeText.text = "<color=black>" + Mathf.Ceil(countTime).ToString() + " √ </color>";
        num = 0;
        clickNumText.text = "" + num;
        QuickJobButton.interactable = true;
        start.SetActive(true);
    }
}
