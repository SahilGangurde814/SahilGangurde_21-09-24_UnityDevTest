using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject GOpanel;
    float timeRemain, totalTime = 120;

    // Update is called once per frame
    void Update()
    {
        timeRemain = totalTime - Time.time;
        if(timeRemain <= 0)
        {
            timeRemain = 0;
            GOpanel.SetActive(true);
        }
        text.text ="Time Remain : " + Mathf.FloorToInt(timeRemain).ToString() + "s";
    }
}
