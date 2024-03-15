using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;
    public static AudioManager instance;
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void PlaySource(int sourceIndex)
    {
        if (_audioSources == null || sourceIndex < 0 || sourceIndex >= _audioSources.Length) return;
        _audioSources[sourceIndex].Play();
    }
}
