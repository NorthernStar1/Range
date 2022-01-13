using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        OpenPausedMenu();
    }

    public void OpenPausedMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameUI.Singleton.ShowOnly(UIManager.UIWindowType.PausedMenu);
    }
}
