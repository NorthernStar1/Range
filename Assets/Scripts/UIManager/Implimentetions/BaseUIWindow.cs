using System.Threading.Tasks;
using UIManager;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BaseUIWindow : MonoBehaviour, IUIWindow
{
    private CanvasGroup _canvasGroup;
    public GameObject Root { get ; set; }
    public bool IsShow { get; set; }

    public virtual async Task Hide()
    {
        IsShow = false;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        var t = 0f;
        while(t < 1)
        {
            t += Time.deltaTime;
            _canvasGroup.alpha = 1f - t;
            await Task.Yield();
        }
        _canvasGroup.alpha = 0f;

    }

    public virtual async Task Initialize()
    {
        IsShow = false;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0f;
        Root = gameObject; 
    }

    public virtual async Task Show()
    {
        IsShow = true;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            _canvasGroup.alpha = t;
            await Task.Yield();
        }
        _canvasGroup.alpha = 1f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

   
}
