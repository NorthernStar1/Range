using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UIManager;

public class PausedMenuWindow : BaseUIWindow
{
    public static bool IsPaused = false;
    public void OpenPauseMenu()
    {
        //Time.timeScale = 0f;
        IsPaused = true;
        GameUI.Singleton.ShowOnly(UIWindowType.PausedMenu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false && SceneManager.GetActiveScene().buildIndex > 0)
            OpenPauseMenu();
    }
    public void Continue()
    {
        IsPaused = false;
        GameUI.Singleton.Hide(UIWindowType.PausedMenu);
        //Time.timeScale = 1f;
    }
    public void OpenSettings()
    {
        Debug.Log("Settings");
    }

    public void OpenMainMenu()
    {
        OpenMenuAsync();
    }

    private async void OpenMenuAsync()
    {
        IsPaused = false;
        
        //await GameUI.Singleton.Show(UIWindowType.LoadingScreen);
        await GameUI.Singleton.Hide(UIWindowType.PausedMenu);
        GameManager.Singleton.LoadMenu();
    }
}
