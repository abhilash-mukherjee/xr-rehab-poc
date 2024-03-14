using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualKeyboardManager : MonoBehaviour
{
    [SerializeField]
    private OVRVirtualKeyboard virtualKeyboard;

    [SerializeField]
    private InputField inputField;
    private void Update()
    {
        if(inputField.isFocused && virtualKeyboard.gameObject.activeInHierarchy == false)
        {
            virtualKeyboard.ChangeTextContext("");
            virtualKeyboard.gameObject.SetActive(true);
            Debug.Log("**Keyboard enabled");
        }

    }
}
