using Game;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{   
    public static async void SceneSwitch(int number)
    {
        await GameUI.Singleton.HideAllWindows();
        GameManager.Singleton.LoadLevel(number);
    }
}
