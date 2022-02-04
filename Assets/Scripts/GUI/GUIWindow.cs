using UnityEngine;

public class GUIWindow : MonoBehaviour
    
{
    private bool _isShowing = true;
    private CanvasGroup _canvasGroup;
    private int _showTest = 0;
    private int _hideTest = 0;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (PausedMenuWindow.IsPaused && _isShowing)
            Hide();
        if (PausedMenuWindow.IsPaused == false && _isShowing == false)
            Show();

    }

    private void Show()
    {
        _isShowing = true;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        ++_showTest;
        Debug.Log($"Show is {_showTest}");
    }
    private void Hide()
    {
        _isShowing = false;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        ++_hideTest;
        Debug.Log($"Hide is {_hideTest}");
    }
}
