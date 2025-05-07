using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;

public class MapController : MonoBehaviour
{
    public static MapController Instance = null;

    public Vector3 InitialSpawnPoint = Vector3.zero;
    public string LevelID = string.Empty;

    void Start()
    {
        print("map controller running");
        EventHandler.Level._LoadedLevel(new LoadedLevelEventArgs(this));
        Debug.Log("MapController: Loading Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
