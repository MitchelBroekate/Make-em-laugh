using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
    public GameObject scripts;
    PopUps popUps;
    float safedTime;
    TMP_Text safedTimeText;

    private void Start()
    {
        popUps = scripts.GetComponent<PopUps>();
    }

    private void Update()
    {
        
    }

    void TimeSafe()
    {
        safedTime = popUps.currentTime;

        TimeSpan time = TimeSpan.FromSeconds(safedTime);
        safedTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
