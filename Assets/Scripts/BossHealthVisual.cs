using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UI namespace

public class BossHealthVisual : MonoBehaviour
{
    [SerializeField] private Slider _Slider;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        // Ensure that _Slider is not null before trying to access its value
        if (_Slider != null)
        {
            _Slider.value = currentValue / maxValue;
        }
    }
}