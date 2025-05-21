using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* All code below has been written by Charlotte, unless marked otherwise. */

public class GodMode : MonoBehaviour
{
    // This method manages whether or not God Mode has been enabled.
    // togglevalue is used as our boolean and will allow us to toggle God Mode on and off depending on the status of the boolean.
    public void GodModeStatus(bool togglevalue)
    {
        if (togglevalue)
        {
            Debug.Log("God Mode Activated");
            Settings.instance.CheatMode = true;
        }

        else
        {
            Debug.Log("God Mode Deactivated.");
            Settings.instance.CheatMode = false;
        }
    }
}
