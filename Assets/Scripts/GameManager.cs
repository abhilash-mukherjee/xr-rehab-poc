using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public delegate void SceneEventHandler(int sceneIndex);
    public static event SceneEventHandler OnSceneLoaded, OnSceneUnloaded;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            Debug.Log("Environmet Loaded");
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void LoadSceneAsync(int sceneIndex)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        asyncOperation.completed += operation => OnSceneLoaded?.Invoke(sceneIndex);
    }
    public void UnloadSceneAsync(int sceneIndex)
    {
        var asyncOperation = SceneManager.UnloadSceneAsync(sceneIndex);
        asyncOperation.completed += operation => OnSceneUnloaded?.Invoke(sceneIndex);
    }
}
