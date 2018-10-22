using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    public void Play(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
