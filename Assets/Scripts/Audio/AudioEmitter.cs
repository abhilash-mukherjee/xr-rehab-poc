using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    public void EmitAudioEvent(int audioIndex)
    {
        AudioManager.instance.PlaySource(audioIndex);
    }
    public void EmitStopAudioEvent(int audioIndex)
    {
        AudioManager.instance.StopSource(audioIndex);
    }
}