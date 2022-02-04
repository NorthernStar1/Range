using System.Threading.Tasks;
using UIManager;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
public class BaseUIWindow : MonoBehaviour, IUIWindow
{
    [Header("Animatoin Hide")]
    [SerializeField] private Ease _EaseHide;
    [SerializeField] private float _DurationPositionHide;
    [SerializeField] private float _DurationAlphaHide;
    [SerializeField] private Vector3 _PosHide;

    [Header("Animatoin Show")]
    [SerializeField] private Ease _EaseShow;
    [SerializeField] private float _DurationPositionShow;
    [SerializeField] private float _DurationAlphaShow;
    [SerializeField] private Vector3 _PosShow;


    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public GameObject Root { get ; set; }
    public bool IsShow { get; set; }

    public virtual async Task Hide()
    {
        IsShow = false;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        await Task.WhenAll(_canvasGroup.DOFade(0, _DurationAlphaHide).SetEase(_EaseHide).AsyncWaitForCompletion(),
             _rectTransform.DOLocalMove(_PosHide, _DurationPositionHide).SetEase(_EaseHide).AsyncWaitForCompletion());
    }

    public virtual async Task Initialize()
    {
        IsShow = false;
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0f;
        Root = gameObject;
        _rectTransform = GetComponent<RectTransform>();
    }

    public virtual async Task Show()
    {
        IsShow = true;
        await Task.WhenAll(_canvasGroup.DOFade(1f, _DurationAlphaShow).SetEase(_EaseShow).AsyncWaitForCompletion(),
            _rectTransform.DOLocalMove(_PosShow, _DurationPositionShow).SetEase(_EaseShow).AsyncWaitForCompletion());

        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

   
}
