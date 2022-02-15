using UIManager;
using Game;

public class LevelListWindow : BaseUIWindow
{
    public async void OpenMainMenu()
    {
        await GameUI.Singleton.ShowOnly(UIWindowType.MainMenu);
    }
    public void OpenFirstLevel()
    {
        GameManager.Singleton.LoadLevel(2);
    }
    public void OpenSecondLevel()
    {
        GameManager.Singleton.LoadLevel(3);
    }
}
