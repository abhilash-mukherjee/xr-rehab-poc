using UnityEngine;

[CreateAssetMenu(fileName ="New Session Time", menuName ="Variables/Session Time")]
public class SessionTime : ScriptableObject
{
    [SerializeField] public string timeString = "";
}