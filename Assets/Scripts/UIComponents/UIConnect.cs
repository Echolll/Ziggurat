using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIConnect : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderUI;
    [SerializeField]
    private TMP_InputField _inputField;

    private void Start()
    {
        _sliderUI.value = 0.0f;
        _inputField.text = _sliderUI.value.ToString();

        _sliderUI.onValueChanged.AddListener(UpdateInputFieldValue);
        _inputField.onEndEdit.AddListener(UpdateSliderValue);
    }

    private void UpdateInputFieldValue(float value)
    {
       _inputField.text = value.ToString();
    }

    private void UpdateSliderValue(string value)
    {
        float floatValue;

        if (float.TryParse(value, out floatValue))
        {
            floatValue = Mathf.Clamp(floatValue, _sliderUI.minValue, _sliderUI.maxValue);
            _sliderUI.value = floatValue;
        }
        
    }
}
