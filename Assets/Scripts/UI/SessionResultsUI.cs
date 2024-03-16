using UnityEngine;
using TMPro;

public class SessionResultsUI : MonoBehaviour
{
    [SerializeField] private SessionAnalyticsData sessionAnalyticsData;
    [SerializeField] TextMeshProUGUI score, accuracy, misses, errors;
    private void OnEnable()
    {
        score.text = "Score: " + sessionAnalyticsData.score.ToString();
        accuracy.text = "Accuracy: " + sessionAnalyticsData.Accuracy.ToString() + "%";
        misses.text = "Misses: " + sessionAnalyticsData.misses.ToString();
        errors.text = "Errors: " + sessionAnalyticsData.errors.ToString();
    }
}