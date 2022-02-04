using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Text StaminaText;
    public Slider Slider;
    public static float _StaminaCurrentValue;
    private float _StaminaMaxValue = 100f;
    private float _StaminaMinValue = 0f;

    private void Awake()
    {
        _StaminaCurrentValue = _StaminaMaxValue;
    }
    private void Update()
    {
        StaminaChange();
    }
    private void StaminaChange()
    {
        if (_StaminaCurrentValue > _StaminaMaxValue) _StaminaCurrentValue = _StaminaMaxValue;
        if (_StaminaCurrentValue < _StaminaMinValue) _StaminaCurrentValue = _StaminaMinValue;

        Slider.value = _StaminaCurrentValue;
        StaminaText.text = Mathf.RoundToInt(_StaminaCurrentValue).ToString() + "/" + _StaminaMaxValue.ToString();

    }
}
