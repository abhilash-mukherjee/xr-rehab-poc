using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public void EndSession()
    {
        SessionManager.instance.KillCurrentSession();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) EndSession();
    }
}
