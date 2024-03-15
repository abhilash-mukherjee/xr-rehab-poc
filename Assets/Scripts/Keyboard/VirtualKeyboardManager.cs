using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualKeyboardManager : MonoBehaviour
{
    private OVRVirtualKeyboard _virtualKeyboard;

    [SerializeField]
    private InputField inputField;
    private void OnEnable()
    {
        GameManager.OnSceneLoaded += CacheKeyboardEssentials;
    }
    private void OnDisable()
    {
        GameManager.OnSceneLoaded -= CacheKeyboardEssentials;
    }

    private void CacheKeyboardEssentials(int sceneIndex)
    {
        if(sceneIndex == 3)
        {
            CacheInput();
        }
    }

    private void CacheInput()
    {
        _virtualKeyboard = GameObject.FindGameObjectWithTag("VirtualKeyBoard").GetComponent<OVRVirtualKeyboard>();
        _virtualKeyboard.TryGetComponent<OVRVirtualKeyboardInputFieldTextHandler>(out var inputFieldHandler);
        inputFieldHandler.InputField = inputField;
    }
    private void Update()
    {
        if (_virtualKeyboard == null) return;
        if(inputField.isFocused && _virtualKeyboard.gameObject.activeInHierarchy == false)
        {
            _virtualKeyboard.ChangeTextContext("");
            _virtualKeyboard.gameObject.SetActive(true);
            Debug.Log("**Keyboard enabled");
        }

    }
}
