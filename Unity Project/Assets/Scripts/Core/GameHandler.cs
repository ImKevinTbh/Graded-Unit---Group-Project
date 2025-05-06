using Assets;
using Events;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;
using Events;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance = null;
    public GameObject Player;

    private void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(this); }
        EventHandler.Init();

        Events.Level.OnLoadedLevel += OnLoadedLevel;
    }

    private void OnDestroy()
    {
        Events.Level.OnLoadedLevel -= OnLoadedLevel;
    }


    private void OnLoadedLevel(LoadedLevelEventArgs ev)
    {
        Debug.Log("GameHandler: Level Loaded");
        Instantiate(Player, transform.parent);
        
    }
}
