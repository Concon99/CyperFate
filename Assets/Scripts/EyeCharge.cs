using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UI namespace

public class EyeCharge : MonoBehaviour
{
    [SerializeField] private Slider _Slider;

    public void UpdateChargeBar(float currentValue, float maxValue)
    {
        // Ensure that _Slider is not null before trying to access its value
        if (_Slider != null)
        {
            _Slider.value = currentValue / maxValue;
        }
    }
}