using Assets;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;
using Events;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance = null;
    public GameObject Player;

    private void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(this); }
        EventHandler.Init();
        Debug.Log("Subscribing to loaded level");
        Events.Level.OnLoadedLevel += OnLoadedLevel;
    }

    private void OnDestroy()
    {
        Events.Level.OnLoadedLevel -= OnLoadedLevel;
    }


    public void OnLoadedLevel(LoadedLevelEventArgs ev)
    {
        Debug.Log("GameHandler: Level Loaded");
        var player = GameObject.Instantiate(Player);
        
        print("Spawned player.");
        //player.transform.SetParent(MapController.Instance.gameObject.transform, true);
        //player.SetActive(true);
        Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = player.transform;;
    }
}
