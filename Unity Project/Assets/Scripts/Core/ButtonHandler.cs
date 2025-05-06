using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OptionsButton()
    {
        Debug.Log("Going to Options Menu...");
    }

    public void CreditsButton()
    {
        Debug.Log("Going to Credits Screen...");
    }

    public void QuitButton()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
