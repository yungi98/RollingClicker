using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryStore : MonoBehaviour
{
    public GameObject lotteryStore;
    public Button lotteryExit;
    void Awake()
    {
        lotteryStore.SetActive(false);
    }
    public void Start()
    {
        lotteryExit.onClick.AddListener(Exit);
    }

    public void OnClickButton()
    {
        lotteryStore.SetActive(true);
    }

    public void Exit()
    {
        lotteryStore.SetActive(false);
    }
}
