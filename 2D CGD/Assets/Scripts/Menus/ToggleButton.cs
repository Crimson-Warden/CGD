using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

abstract class ToggleButton : Button
{
    protected abstract void OnToggleOn();
    protected abstract void OnToggleOff();
    bool toggled = false;

    protected override void Start()
    {
        base.Start();
        FindObjectOfType<AudioManager>().ChangeVolume += ResetColor;
    }

    void ResetColor(float ignore)
    {
        ColorBlock cb = ColorBlock.defaultColorBlock;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.white;
        cb.pressedColor = Color.white;
        GetComponent<Button>().colors = cb;
    }

    public void Toggle()
    {
        ColorBlock cb = ColorBlock.defaultColorBlock;
        if(toggled)
        {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            cb.pressedColor = Color.white;
            OnToggleOff();
        }
        else
        {
            cb.normalColor = Color.blue;
            cb.highlightedColor = Color.blue;
            cb.pressedColor = Color.blue;
            OnToggleOn();
        }
        toggled = !toggled;
        GetComponent<Button>().colors = cb;
    }
}
