using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldText;
    public Text countText;

    private DataController DataC()
    {
        return DataController.Instance;
    }

    void Update()
    {    
        goldText.text = "µ· : " + DataC().gold;
        countText.text = DataC().m_count.ToString();
    }
}
