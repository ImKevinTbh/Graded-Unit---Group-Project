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
using MEC;
public class GameHandler : MonoBehaviour
{
    public static GameHandler instance = null;
    public GameObject Player;
    GameObject PObject = null;

    private void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(this); }
        EventHandler.Init();
        Events.Level.OnLoadedLevel += LoadedLevel;
    }

    private void OnDestroy()
    {   
        
    }


    public void LoadedLevel(LoadedLevelEventArgs ev)
    {
        Debug.Log("GameHandler: Level Loaded");
        Timing.CallDelayed(0.15f, () =>
        {
            if (PlayerController.Instance == null)
            {
                Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity);
            }


        });
        
        print("Spawned player.");
        //player.transform.SetParent(MapController.Instance.gameObject.transform, true);
        //player.SetActive(true);
        
        Timing.CallDelayed(0.17f, () => Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = PlayerController.Instance.gameObject.transform);
    }
}
