using UnityEngine;

public class SessionAnalyticsManager  : MonoBehaviour
{
    [SerializeField] SessionAnalyticsData sessionAnalyticsData;
    [SerializeField] private int scorePerSuccess;
    private void OnEnable()
    {
        GameBoardButton.OnSuccess += Success;
        GameBoardButton.OnError += Error;
        GameBoardButton.OnMiss += Miss;
        GameBoardManager.OnBeep += Beep;
    }
    private void OnDisable()
    {
        GameBoardButton.OnSuccess -= Success;
        GameBoardButton.OnError -= Error;
        GameBoardButton.OnMiss -= Miss;
        GameBoardManager.OnBeep -= Beep;
    }

    private void Start()
    {
        sessionAnalyticsData.Reset();
    }
    private void Beep(int btnId, bool isRed)
    {
        Debug.Log("Beep");
        sessionAnalyticsData.beeps++;
    }

    private void Error()
    {
        Debug.Log("Error");
        sessionAnalyticsData.errors++;
    }

    private void Miss()
    {
        Debug.Log("Miss");
        sessionAnalyticsData.misses++;
    }

    private void Success()
    {
        Debug.Log("Success");
        sessionAnalyticsData.score += scorePerSuccess;
    }
}
