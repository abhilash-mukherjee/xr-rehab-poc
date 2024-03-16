using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] TimerManager timerManager;
    [SerializeField] GameObject gameBoard, resultPanel;
    [SerializeField] GameBoardManager gameBoardManager;
    private void OnEnable()
    {
        timerManager.onTimerEnd += TimerEnd;
    }
    private void OnDisable()
    {
        timerManager.onTimerEnd -= TimerEnd;
    }

    private void TimerEnd()
    {
        gameBoard.SetActive(false);
        resultPanel.SetActive(true);
        gameBoardManager.PauseGameBoard();
    }

    public void StartGamePlay()
    {
        timerManager.StartTimer(SessionManager.instance.currentSessionData.durationInSeconds);
        gameBoard.SetActive(true);
    }
}
