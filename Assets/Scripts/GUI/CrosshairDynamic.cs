using UnityEngine;

public class CrosshairDynamic : MonoBehaviour
{
    [SerializeField] private RectTransform _crosshairSize;
    [SerializeField] private float _currentSize;
    [SerializeField] private float _SmoothSpeed = 10f;
    public static CrosshairDynamic Singleton;
    private void Awake()
    {
        Singleton = this;
    }

    public void CrosshairSetup(float newSize)
    {
        _currentSize -= (_currentSize - newSize) * Time.deltaTime * _SmoothSpeed;
        _crosshairSize.sizeDelta = new Vector2(_currentSize, _currentSize);
    }
}
