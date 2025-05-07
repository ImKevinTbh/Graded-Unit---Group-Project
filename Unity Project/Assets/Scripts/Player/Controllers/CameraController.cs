using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using EventArgs;
using Events;
using MEC;

public class CameraController : MonoBehaviour
{


    public static CameraController instance = null;

    // initialises variable to hold player reference
    public GameObject p;


    private void Start()
    {

        instance = this;

        // checks for the player object and assigns it to the p variable


        // subscribes the door open trigger function to the boss arena enter event
        Events.Level.BossArenaEnter += doorOpenTrigger;
        Events.Level.OnLoadedLevel += OnLoadedLevel;
 
    }

    private void OnLoadedLevel(LoadedLevelEventArgs ev)
    {
        Timing.CallDelayed(0.5f, () =>  p = PlayerController.Instance.gameObject );

        Debug.Log("Camera: Level Loaded");
    }

    private void Update()
    {
        // every frame moves the cameras possition to focus on the player
        if (p != null) { gameObject.transform.position = new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z - 1f); }
    }


    private void doorOpenTrigger()
    {
        // when the boss arena enter event is triggered this camera is enabled
        this.gameObject.SetActive(false);
        
    }
}
