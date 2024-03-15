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
            durationInSeconds = 120,
            speedOfSession = 5
        };
        return sessionData;
    }
}
