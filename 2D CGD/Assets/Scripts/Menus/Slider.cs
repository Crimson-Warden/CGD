using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

abstract class Slider : MonoBehaviour
{
    protected delegate void SliderValue(float value);
    protected SliderValue sliderValue; 
    float previousValue;

    void Update()
    {
        var value = GetComponentInChildren<UnityEngine.UI.Slider>().value;
        if(value != previousValue)
        {
            sliderValue(value);
        }
        previousValue = value;
    }
}
