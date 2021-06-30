using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDelayBar : MonoBehaviour
{
    public Image clickD; //앞
    public GameObject delayBar;
    public Button clkBtn;

    public float duration;
    public float currentTime;

    private Button btn;

    public Text decimalText;
    public float dil = 0;

    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public Button nodeButton1;
    public Button nodeButton2;
    public Button nodeButton3;

    private float RandomX;
    private float RandomY;
    public Vector2 RandomPos;

    GameManager GMD;

    void Awake()
    {
        GMD = GameManager.Instance;
        delayBar.SetActive(false);
        btn = clkBtn.GetComponent<Button>();
        decimalText.text = "." + dil;

        NodeSetting();
        nodeButton1.onClick.AddListener(OnClicknodeButton1);
        nodeButton2.onClick.AddListener(OnClicknodeButton2);
        nodeButton3.onClick.AddListener(OnClicknodeButton3);
    }

    public void Delay()
    {
        btn.interactable = false;
        delayBar.SetActive(true);
        duration = GMD.playerData.clickDelay;
        currentTime = duration;
        clickD.fillAmount = 1;
        dil = 100;
        NodeStrat();
        StartCoroutine(DelayTime());
    }
    WaitForSeconds seconds = new WaitForSeconds(0.01f);
    IEnumerator DelayTime()
    {
        while(currentTime > 0)
        {
            currentTime -= 0.01f;
            clickD.fillAmount = currentTime / duration;
            if(dil > 0)
            {
                dil -= 1 / duration;
            }  
            decimalText.text = "." + (int)dil;
            yield return seconds;
        }
        if(nodeButton1.interactable == false && nodeButton2.interactable == false && nodeButton3.interactable == false)
        {
            GMD.playerData.count -= 3;
            if (GMD.playerData.count <= 1)
            {
                GMD.playerData.count += GMD.playerData.saveCount;
                GMD.playerData.gold += 10000;
            }
        }
        dil = 0;
        decimalText.text = "." + (int)dil;
        clickD.fillAmount = 0;
        currentTime = 0;
        delayBar.SetActive(false);
        btn.interactable = true;
        NodeSetting();
    }

    public void NodeSetting()
    {
        node1.SetActive(false);
        node2.SetActive(false);
        node3.SetActive(false);
        nodeButton1.interactable = true;
        nodeButton2.interactable = true;
        nodeButton3.interactable = true;
    }
    public void NodeStrat()
    {
        // -2 < x < 2.5 , -1.5 < y < 3
        RandomX = UnityEngine.Random.Range(-1.7f, -0.5f);
        RandomY = UnityEngine.Random.Range(-1.5f, 3);
        RandomPos = new Vector2(RandomX, RandomY);
        node1.transform.position = RandomPos;

        RandomX = UnityEngine.Random.Range(0, 1);
        RandomY = UnityEngine.Random.Range(-1.5f, 3);
        RandomPos = new Vector2(RandomX, RandomY);
        node2.transform.position = RandomPos;

        RandomX = UnityEngine.Random.Range(1.5f, 2.3f);
        RandomY = UnityEngine.Random.Range(-1.5f, 3);
        RandomPos = new Vector2(RandomX, RandomY);
        node3.transform.position = RandomPos;

        node1.SetActive(true);
        node2.SetActive(true);
        node3.SetActive(true);
    }

    public void OnClicknodeButton1()
    {
        nodeButton1.interactable = false;
    }
    public void OnClicknodeButton2()
    {
        nodeButton2.interactable = false;
    }
    public void OnClicknodeButton3()
    {
        nodeButton3.interactable = false;
    }
    
}
