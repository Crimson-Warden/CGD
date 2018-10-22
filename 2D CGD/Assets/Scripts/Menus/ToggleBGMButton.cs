using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ToggleBGMButton : ToggleButton
{
    protected override void OnToggleOff()
    {
        FindObjectOfType<AudioManager>().ToggleMute();
    }

    protected override void OnToggleOn()
    {
        FindObjectOfType<AudioManager>().ToggleMute();
    }
}
