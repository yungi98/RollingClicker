using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryButton : MonoBehaviour
{
    public Slider moveSlide;
    public GameObject slideBar;
    public GameObject slideBack;
    public Button button;

    public float currentTime;

    public int ticketNomber = 1;

    public GameObject result;
    public Text resultText;

    public GameObject lotteryPage;
    public GameObject lottery1;
    public Button lottery1Btn;
    public GameObject lottery2;
    public Button lottery2Btn;

    public float rand;

    public GameObject lotteryStore;

    GameManager GMD;

    void Awake()
    {
        slideBar.SetActive(false);
        slideBack.SetActive(false);
        result.SetActive(false);
        lotteryPage.SetActive(false);
    }

    public void Start()
    {
        GMD = GameManager.Instance;
        lottery1Btn.onClick.AddListener(Lottery1Click);
        lottery2Btn.onClick.AddListener(Lottery2Click);
        button.onClick.AddListener(OnClickButton);
    }

    WaitForSeconds seconds = new WaitForSeconds(0.01f);
    public void OnClickButton()
    {
        if(GMD.playerData.gold >= 1000)
        {
            lotteryPage.SetActive(true);
            GMD.playerData.gold -= 1000;
            lotteryStore.SetActive(false);
        }
    }

    public void Lottery1Click()
    {
        lottery2.SetActive(false);
        lotteryPage.SetActive(false);
        Setting();
    }
    public void Lottery2Click()
    {
        lottery1.SetActive(false);
        lotteryPage.SetActive(false);
        Setting();
    }

    public void Setting()
    {
        currentTime = 0;
        moveSlide.value = 0;
        button.interactable = false;
        slideBack.SetActive(true);
        slideBar.SetActive(true);   
        StartCoroutine(DlayTime());
    }

    public void reSetting()
    {
        button.interactable = true;
        slideBar.SetActive(false);
        slideBack.SetActive(false);
        result.SetActive(false);
        lotteryPage.SetActive(false);
        lottery1.SetActive(true);
        lottery2.SetActive(true);
    }

    IEnumerator DlayTime()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        while (currentTime < 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                break;
            }
            currentTime += Time.deltaTime;
            moveSlide.value = currentTime;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        if (moveSlide.value <= 0.87 || moveSlide.value >= 0.96)
        {
            resultText.text = "<color=red>½ÇÆÐ</color>";
            result.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        else 
        {
            resultText.text = "<color=blue>¼º°ø</color>";
            result.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            result.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            rand = Random.Range(0.1f, 1.0f);
            if (rand > 0.5f)
            {
                switch (ticketNomber)
                {
                    case 1:
                        GMD.playerData.gold += 2000;
                        break;
                    default:
                        GMD.playerData.gold += 1000;
                        break;
                }
                resultText.text = "<color=blue>´çÃ·</color>";
                result.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            else 
            {
                resultText.text = "<color=red>²Î</color>";
                result.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            
        }
        reSetting();
    }
}
