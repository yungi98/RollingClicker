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

    public GameObject success;
    public GameObject fail;

    public GameObject lotteryPage;
    public GameObject lottery1;
    public Button lottery1Btn;
    public GameObject lottery2;
    public Button lottery2Btn;

    public float rand;

    public GameObject lotteryStore;

    private DataController DataC()
    {
        return DataController.Instance;
    }

    void Awake()
    {
        slideBar.SetActive(false);
        slideBack.SetActive(false);
        success.SetActive(false);
        fail.SetActive(false);
        lotteryPage.SetActive(false);
    }

    public void Start()
    {
        lottery1Btn.onClick.AddListener(Lottery1Click);
        lottery2Btn.onClick.AddListener(Lottery2Click);
        button.onClick.AddListener(OnClickButton);
    }

    WaitForSeconds seconds = new WaitForSeconds(0.01f);
    public void OnClickButton()
    {
        if(DataC().gold >= 1)
        {
            lotteryPage.SetActive(true);           
            DataC().gold -= 1;
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
        success.SetActive(false);
        fail.SetActive(false);
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
            fail.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        else 
        {
            success.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            success.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            rand = Random.Range(0.1f, 1.0f);
            if (rand > 0.5f)
            {
                switch (ticketNomber)
                {
                    case 1:
                        DataC().gold += 2;
                        break;
                    default:
                        DataC().gold += 1;
                        break;
                }
                success.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            else 
            {
                fail.SetActive(true);
                yield return new WaitForSeconds(1);
            }
            
        }
        reSetting();
    }
}
