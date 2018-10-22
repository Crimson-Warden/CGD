using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    GameObject previousScreen;

    public void ReturnToPrevious(GameObject optionsMenu)
    {
        optionsMenu.SetActive(false);
        previousScreen.SetActive(true);
    }

    public void SetPreviousScreen(GameObject screen)
    {
        previousScreen = screen;
    }

    public void UpdateSliderText(UnityEngine.UI.Slider slider)
    {
        slider.transform.GetComponentsInChildren<Text>()[0].text = slider.value.ToString();
    }
}
