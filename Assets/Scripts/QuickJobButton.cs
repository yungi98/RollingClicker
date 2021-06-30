using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuickJobButton : MonoBehaviour
{
    public GameObject quickJobBtn;
    public GameObject quickJobpanel;
    public Button quickJobButton;

    public bool onOff = false; 

    public void buttonClick()
    {
        if(onOff == false)
        {
            onOff = true;
            quickJobButton.interactable = false;
            quickJobBtn.transform.DOLocalMoveX(980, 0.5f).SetRelative().OnComplete(() =>
            {
                quickJobButton.interactable = true;
            });
            quickJobpanel.transform.DOLocalMoveX(1080, 0.5f).SetRelative().OnComplete(() =>
            {
                quickJobButton.interactable = true;
            });
        }
        else
        {
            onOff = false;
            quickJobButton.interactable = false;
            quickJobBtn.transform.DOLocalMoveX(-980, 0.5f).SetRelative().OnComplete(() =>
            {
                quickJobButton.interactable = true;
            });
            quickJobpanel.transform.DOLocalMoveX(-1080, 0.5f).SetRelative().OnComplete(() =>
            {
                quickJobButton.interactable = true;
            });
        }
    }
}
