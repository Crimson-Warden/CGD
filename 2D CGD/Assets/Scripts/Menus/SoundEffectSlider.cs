using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class SoundEffectSlider : Slider
{
    void Start()
    {
        sliderValue = SoundEffects;
    }

    void SoundEffects(float value)
    {
        value /= 100;
        Debug.Log(value);
        FindObjectOfType<AudioManager>().ChangeVolume(value);
    } 
}
