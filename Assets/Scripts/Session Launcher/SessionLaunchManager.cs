using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionLaunchManager : MonoBehaviour
{
    public void LaunchSession(InputField sessionCodeInput)
    {
        Debug.Log("session launch requested");
        SessionManager.instance.LaunchSession(sessionCodeInput.text);
    }
}

public struct SessionData
{
    public string sessionCode;
    public string language;
    public int durationInSeconds;
    [Range(0,10)]
    public float beepGap;
}