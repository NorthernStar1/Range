using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _PausedMenu;
    [SerializeField] private GameObject _GUI;
    public static bool _IsPaused = false;

    private void Awake()
    {
        _PausedMenu.SetActive(false);
    }
    private void Update()
    {
        ActiveMenu();
    }
    private void ActiveMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _IsPaused = !_IsPaused;
        }
        if(_IsPaused)
        {
            _PausedMenu.SetActive(true);
            _GUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            _PausedMenu.SetActive(false);
            _GUI.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void Continue()
    {
        _IsPaused = false;
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
