using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIManager;

public class LevelListWindow : BaseUIWindow
{
    public void OpenMainMenu()
    {
        GameUI.Singleton.ShowOnly(UIWindowType.MainMenu);
    }
}
