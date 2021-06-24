using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDlayBar : MonoBehaviour
{
    public Image clickD; //앞
    public GameObject dlayBar;
    public Button clkBtn;

    public float duration;
    public float currentTime;

    private Button btn;

    public Text decimalText;
    public int dil = 0;

    private DataController DataC()
    {
        return DataController.Instance;
    }

    void Awake()
    {
        dlayBar.SetActive(false);
        btn = clkBtn.GetComponent<Button>();
    }

    public void Dlay()
    {
        btn.interactable = false;
        dlayBar.SetActive(true);
        duration = DataC().m_clickDlay;
        currentTime = duration;
        clickD.fillAmount = 1;
        dil = 100;
        StartCoroutine(DlayTime());
    }
    WaitForSeconds seconds = new WaitForSeconds(0.01f);
    IEnumerator DlayTime()
    {
        while(currentTime > 0)
        {
            currentTime -= 0.01f;
            clickD.fillAmount = currentTime / duration;
            if(dil > 0)
            {
                dil -= 1;
            }  
            decimalText.text = "." + dil;
            yield return seconds;
        }
        clickD.fillAmount = 0;
        currentTime = 0;
        dlayBar.SetActive(false);
        btn.interactable = true;
    }
}
