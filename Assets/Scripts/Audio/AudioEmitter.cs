using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    public void EmitAudioEvent(int audioIndex)
    {
        AudioManager.instance.PlaySource(audioIndex);
    }
}