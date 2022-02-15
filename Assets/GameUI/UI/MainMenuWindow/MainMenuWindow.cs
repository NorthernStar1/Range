using Game;
using UIManager;
using UnityEngine;

public class MainMenuWindow : BaseUIWindow
{
   public async void OpenLevelList()
    {
        await GameUI.Singleton.ShowOnly(UIWindowType.LevelList);
    }

    public void StartGame()
    {
        GameManager.Singleton.LoadLevel(2);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void OpenSettings()
    {
        Debug.Log("Settings");
    }
}
