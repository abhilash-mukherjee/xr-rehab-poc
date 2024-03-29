﻿using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance;
    public SessionData currentSessionData;
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void LaunchSession(string sessionCode)
    {
        if (!string.IsNullOrEmpty(currentSessionData.sessionCode) || sessionCode.Length < 6)
        {
            Debug.Log($"Session launch failed. current session code={currentSessionData.sessionCode}, passed code = {sessionCode}");
            return;
        }
        var sessionData = SessionDataHelper.GetSessionData(sessionCode);
        currentSessionData = sessionData;
        GameManager.instance.UnloadSceneAsync(0);
        GameManager.instance.LoadSceneAsync(2);
        Debug.Log($"Session Launched./n Session Data: [Lang={sessionData.language} Duration={sessionData.durationInSeconds} secs Speed={sessionData.speedOfSession} ]");
    }
    public void KillCurrentSession()
    {
        if (string.IsNullOrEmpty(currentSessionData.sessionCode))
        {
            Debug.Log($"Session kill failed. No Active session");
            return;
        }
        var debugCode = currentSessionData.sessionCode;
        currentSessionData = SessionDataHelper.GetEmptySession();
        GameManager.instance.UnloadSceneAsync(2);
        GameManager.instance.LoadSceneAsync(0);
        Debug.Log($"Session Killed. Code = {debugCode}");
    }
}
