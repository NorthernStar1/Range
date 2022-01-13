using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static async void SceneSwitch(int number)
    {
        await GameUI.Singleton.HideAllWindows();
        SceneManager.LoadScene(number);   
    }
}
