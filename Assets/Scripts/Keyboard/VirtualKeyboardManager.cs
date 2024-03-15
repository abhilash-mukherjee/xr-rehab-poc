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

    private void Start()
    {
        _virtualKeyboard = FindAnyObjectByType<OVRVirtualKeyboard>();
        _virtualKeyboard.gameObject.TryGetComponent<OVRVirtualKeyboardInputFieldTextHandler>(out var inputFieldHandler);
        inputFieldHandler.InputField = inputField;
    }
    private void Update()
    {
        if(inputField.isFocused && _virtualKeyboard.gameObject.activeInHierarchy == false)
        {
            _virtualKeyboard.ChangeTextContext("");
            _virtualKeyboard.gameObject.SetActive(true);
            Debug.Log("**Keyboard enabled");
        }

    }
}
