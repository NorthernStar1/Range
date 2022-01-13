using System.Collections;
using System.Collections.Generic;
using UIManager;
using UnityEngine;

public class MainMenuWindow : BaseUIWindow
{
   public void OpenLevelList()
    {
        GameUI.Singleton.ShowOnly(UIWindowType.LevelList);
    }

    public void StartGame()
    {
        SceneSwitcher.SceneSwitch(1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
