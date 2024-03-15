using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    public event Action onTimerEnd;

    private float currentTime;
    private float sessionTime;
    private bool isTimerRunning = false;
    private bool isTimerPaused = false;
    [SerializeField] private SessionTime sessionTimeString;
    public void StartTimer(int sessionTimeInSeconds)
    {
        if (!isTimerRunning && !isTimerPaused)
        {
            sessionTime = sessionTimeInSeconds;
            currentTime = sessionTimeInSeconds;
            isTimerRunning = true;
            isTimerPaused = false;
            sessionTimeString.timeString = "00:00";
            StartCoroutine(UpdateTimer());
        }
    }

    public void PauseTimer()
    {
        isTimerPaused = true;
    }

    private System.Collections.IEnumerator UpdateTimer()
    {
        while (currentTime > 0)
        {
            if (!isTimerPaused)
            {
                currentTime -= Time.deltaTime;
                if (currentTime < 0) currentTime = 0;
                UpdateTimeString();
            }
            yield return null;
        }

        isTimerRunning = false;
        onTimerEnd?.Invoke();
    }

    private void UpdateTimeString()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        sessionTimeString.timeString = timerString;
    }
}
