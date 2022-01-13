using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : BaseUIWindow
{
    public void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameUI.Singleton.ShowOnly(UIManager.UIWindowType.PausedMenu);
  
        }
    }
    private void Update()
    {
        OpenPauseMenu();
    }
    public void Continue()
    {
        GameUI.Singleton.Hide(UIManager.UIWindowType.PausedMenu);
    }
    public void OpenSettings()
    {
        Debug.Log("Settings");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
