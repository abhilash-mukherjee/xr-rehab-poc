using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private SessionTime sessionTime;
    private void Update()
    {
        timerText.text = sessionTime.timeString;
    }
}
