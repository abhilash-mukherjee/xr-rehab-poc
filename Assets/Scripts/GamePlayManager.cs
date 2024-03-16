using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] TimerManager timerManager;
    [SerializeField] GameObject gameBoard, resultPanel;
    [SerializeField] GameBoardManager gameBoardManager;
    public delegate void GamePlayHandler();
    public static event GamePlayHandler OnGameplayStarted;
    private void OnEnable()
    {
        TimerManager.OnTimerEnd += TimerEnd;
    }
    private void OnDisable()
    {
        TimerManager.OnTimerEnd -= TimerEnd;
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
        OnGameplayStarted?.Invoke();

    }
}
