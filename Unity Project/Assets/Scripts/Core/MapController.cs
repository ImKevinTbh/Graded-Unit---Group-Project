using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using UnityEditor;
using MEC;

public class MapController : MonoBehaviour
{
    public static MapController Instance = null;

    public Vector3 InitialSpawnPoint = Vector3.zero;
    public string LevelID = string.Empty;
    
    
    void Start()
    {
        if (Instance == null) {Instance = this;}
    }


    public void Init()
    {
        print("map controller running");

        Debug.Log("MapController: Loading Level");
        EventHandler.Level._LoadedLevel(new LoadedLevelEventArgs(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
