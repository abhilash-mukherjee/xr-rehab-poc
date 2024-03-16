using UnityEngine;

[CreateAssetMenu(fileName ="New Session Analytics", menuName ="Variables/ Session Analytics")]
public class SessionAnalyticsData : ScriptableObject
{
    public int score;
    public int misses;
    public int errors;
    public int beeps;


    public int Accuracy
    {
        get
        {
            Debug.Log($"Beeps= {beeps}, misses={misses}, errors={errors}, b-m-e = {beeps - errors - misses}, b-m={beeps - misses}, " +
                $"ratio={(beeps - misses - errors) / (beeps - misses)}");
            return (int)Mathf.Round((float)((float)(beeps - misses - errors) / (float)(beeps - misses)) * 100);
        }
    }


    public void Reset()
    {
        score = 0;
        misses = 0;
        errors = 0;
        beeps = 0;
    }
}