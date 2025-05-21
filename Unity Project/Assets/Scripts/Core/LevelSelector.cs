using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventArgs;
using Events;


/* All Code Below This Point Has Been Written By Charlotte, Unless Stated Otherwise */
public class LevelSelector : MonoBehaviour
{
    // This method manages the functions for the Tutorial Level's button.
    // The LoadTutorial text in yellow represents that it is a method.
    // When the player presses the button, it will load them into the tutorial level.
    public void LoadTutorial()
    {
        Debug.Log("Loading Limbo...");
        SceneManager.LoadScene("LimboScene");
        
    }

    // This method manages the functions for the button assigned to the 1st level, Grief.
    // When the player presses the button, it will load them into the Grief level.
    public void LoadGrief()
    {
        Debug.Log("Loading Grief...");
        SceneManager.LoadScene("GriefScene");
    }

    // This method manages the functions for the button assigned to the 2nd level, Denial.
    // When the player presses the button, it will load them into the Denial level.
    public void LoadDenial()
    {
        Debug.Log("Loading Denial...");
        SceneManager.LoadScene("DenialScene");
    }

    // This method manages the functions for the button assigned to the 3rd level, Anger.
    // When the player presses the button, it will load them into the Anger level.
    public void LoadAnger()
    {
        Debug.Log("Loading Anger...");
        SceneManager.LoadScene("AngerScene");
    }

    // This method manages the functions for the button assigned to the 4th level, Bargaining.
    // When the player presses the button, it will load them into the Bargaining level.
    public void LoadBargaining()
    {
        Debug.Log("Loading Bargaining...");
        SceneManager.LoadScene("Bargaining");
    }

    // This method manages the functions for the button assigned to the 5th level, Depression.
    // When the player presses the button, it will load them into the Depression level.
    public void LoadDepression()
    {
        Debug.Log("Loading Depression...");
    }

    // This method manages the functions for the button assigned to the 6th level, Acceptance.
    // When the player presses the button, it will load them into the Acceptance level.
    public void LoadAcceptance()
    {
        Debug.Log("Loading Acceptance...");
    }
}
