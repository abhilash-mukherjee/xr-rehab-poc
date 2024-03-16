using UnityEngine;

public static class SessionDataHelper
{
    public static SessionData GetSessionData(string sessionCode)
    {
        Debug.Log("Session Requested: " + sessionCode);
        var sessionData = new SessionData
        {
            sessionCode = sessionCode,
            language = "english",
            durationInSeconds = 20,
            beepGap = 5
        };
        return sessionData;
    }
    public static SessionData GetEmptySession()
    {
        var sessionData = new SessionData
        {
            sessionCode = "",
            language = "",
            durationInSeconds = 0,
            beepGap = 0
        };
        return sessionData;
    }
}
