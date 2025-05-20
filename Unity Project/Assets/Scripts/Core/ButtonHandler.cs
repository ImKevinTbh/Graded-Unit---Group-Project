using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    /* All Code below this point has been written by Charlotte, unless where labled otherwise. */

    // This method manages the functions for our play button. The PlayButton text in yellow represents that it is a method.
    // When the button is pressed, it will load the player into the Level Select Screen.
    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // This method manages the functions for the options button.
    // When the button is pressed, it will load the player into the options menu.
    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    // This method manages the functions for the tutorial button.
    // When the button is pressed, it loads the player into the Tutorial screen.
    public void TutorialButton()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    // This method manages the functions for the credits button.
    // When the button is pressed, it loads the player into the Credits screen.
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    // This method manages the functions for the Quit button.
    // When the button is pressed, it will safely close the game.
    public void QuitButton()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    // This method manages the functions for the back button.
    // When the button is pressed, it sends the player back to the main menu. This will be on the options and credit screens.
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
