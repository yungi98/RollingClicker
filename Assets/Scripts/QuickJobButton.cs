using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuickJobButton : MonoBehaviour
{
    public GameObject quickJobButton;

    public void buttonClick()
    {
        quickJobButton.transform.DOMoveX(transform.position.x + 5.1f, 1);
    }
}
