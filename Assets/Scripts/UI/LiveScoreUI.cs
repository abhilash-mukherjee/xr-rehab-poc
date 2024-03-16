using UnityEngine;
using TMPro;

public class LiveScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private SessionAnalyticsData sessionAnalyticsData;
    private void Update()
    {
        scoreText.text = sessionAnalyticsData.score.ToString();
    }
}
