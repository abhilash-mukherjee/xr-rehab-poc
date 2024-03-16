using System;
using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    [SerializeField] public GameObject sphereModel;
    private void OnEnable()
    {
        GamePlayManager.OnGameplayStarted += ShowSpheres;
        TimerManager.OnTimerEnd += HideSpheres;
    }
    private void OnDisable()
    {
        GamePlayManager.OnGameplayStarted -= ShowSpheres;
        TimerManager.OnTimerEnd -= HideSpheres;
    }

    private void HideSpheres()
    {
        sphereModel.SetActive(false);
    }

    private void ShowSpheres()
    {
        sphereModel.SetActive(true);
    }
}