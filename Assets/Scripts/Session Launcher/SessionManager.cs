using UnityEngine;

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
        Debug.Log($"Session Launched./n Session Data: [Lang={sessionData.language} Duration={sessionData.durationInSeconds} secs Speed={sessionData.speedOfSession} ]");
    }
    
}
