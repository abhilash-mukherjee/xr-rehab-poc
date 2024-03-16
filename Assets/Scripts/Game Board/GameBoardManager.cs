using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    private bool isGameBoardRunning = false;
    private bool isGameBoardPaused = false;
    private float beepGap;
    private System.Random random;
    public delegate void BeepHandler(int btnId, bool isRed);
    public static event BeepHandler OnBeep;

    private void Start()
    {
        StartBoard(SessionManager.instance.currentSessionData.beepGap);
    }
    void StartBoard(float BeepGap)
    {
        beepGap = Mathf.Round(BeepGap * 10) / 10; // Round off to the nearest decisecond
        if (!isGameBoardRunning && !isGameBoardPaused)
        {
            isGameBoardRunning = true;
            random = new System.Random();
            InvokeRepeating("GenerateRandomValue", 1f, beepGap);
        }
    }

    public void PauseGameBoard()
    {
        isGameBoardPaused = true;
        CancelInvoke("GenerateRandomValue");
    }

    private void GenerateRandomValue()
    {
        int randomNumber = random.Next(1, 10); // Generate random integer between 1 and 9
        bool randomBoolean = (random.Next(0, 2) == 0); // Generate random boolean
        OnBeep?.Invoke(randomNumber, randomBoolean);
        Debug.Log("Random Number: " + randomNumber + ", Random Boolean: " + randomBoolean);
    }
}
