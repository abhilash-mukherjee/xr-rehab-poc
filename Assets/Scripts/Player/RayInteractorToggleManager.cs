using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractorToggleManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnSceneLoaded += OnSceneLoaded;
        GameManager.OnSceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        GameManager.OnSceneLoaded -= OnSceneLoaded;
        GameManager.OnSceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(int sceneIndex)
    {
        if (sceneIndex == 0) ToggleRayInteractor(false);
    }

    private void OnSceneLoaded(int sceneIndex)
    {
        if (sceneIndex == 0) ToggleRayInteractor(true);
    }

    public void ToggleRayInteractor(bool enabled)
    {
        var rayHelpers = FindObjectsOfType<OVRRayHelper>();
        if(rayHelpers != null && rayHelpers.Length != 0)
        {
            for(int i = 0; i < rayHelpers.Length; i++)
            {
                var objTransform = rayHelpers[i].gameObject.transform;
                var ray = objTransform.Find("Ray");
                var cursor = objTransform.Find("Cursor");
                ray.TryGetComponent<MeshRenderer>(out var meshRenderer);
                cursor.TryGetComponent<SpriteRenderer>(out var spriteRenderer);
                if (meshRenderer) meshRenderer.enabled = enabled;
                if (spriteRenderer) spriteRenderer.enabled = enabled;
            }
        }
    }
}
