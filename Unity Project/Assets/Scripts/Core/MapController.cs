using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using UnityEditor;
using MEC;

public class MapController : MonoBehaviour // Kevin
{
    public static MapController Instance = null; // Declare Instance Variable, This allows us to find THIS SPECIFIC SCRIPT without doing gameobject.find because it is performance heavy

    public Vector3 InitialSpawnPoint = Vector3.zero;
    public string LevelID = string.Empty;
    // Required Parameters to be set in editor for each level, if these are not set the game will crash upon trying to load the level
    
    void Start()
    {
        if (Instance == null) {Instance = this;} // if the instance does not exist, set it to this object
    }


    public void Init()
    {
        Debug.Log("Map controller running");


        EventHandler.Level._LoadedLevel(new LoadedLevelEventArgs(this)); // Trigger the "LevelLoaded" event
        Debug.Log("MapController: Loading Level");
    }
    
}
