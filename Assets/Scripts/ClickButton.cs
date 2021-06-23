using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    private DataController DataC()
    {
        return DataController.Instance;
    }

    public void OnClick()
    {
        if(DataC().m_count <= 1)
        {
            DataC().m_count += DataC().m_saveCount;
            DataC().gold += 1;
        }
        DataC().m_count -= 1;
        GameObject.Find("Canvas").GetComponent<ClickDlayBar>().Dlay();
    }
}
