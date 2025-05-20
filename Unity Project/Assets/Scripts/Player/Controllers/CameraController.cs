using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using EventArgs;
using Events;
using MEC;


//Most code writed by Allan unless stated otherwise
public class CameraController : MonoBehaviour
{

    // initialises variable to hold player reference
    public GameObject p;


    public static CameraController instance; // Do not remove, needed for movement controller.


    // initialises variables, subscribes to boss arena enter, exit and level loaded events, sets dampening for transitions between camera bounds, and sets default camera bounds
    private void Start()
    {
        instance = this; // Do not remove, needed for movement controller.

        // subscribes the door open trigger function to the boss arena enter event
        Events.Level.BossArenaEnter += BossArenaEnter;


        Events.Level.OnBossArenaExit += BossArenaExit;

        Events.Level.OnLoadedLevel += OnLoadedLevel;

        gameObject.GetComponent<CinemachineConfiner2D>().m_Damping = 1.5f;
        gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = LevelBounds.instance.gameObject.GetComponent<Collider2D>();

    }


    //Kevin
    // when the level is loaded after a half second delay sets p as the player game object
    private void OnLoadedLevel(LoadedLevelEventArgs ev)
    {
        Timing.CallDelayed(0.5f, () =>  p = PlayerController.Instance.gameObject );

        Debug.Log("Camera: Level Loaded");
    }

    //Kevin
    // updates camera possition to players current possition
    private void Update()
    {
        if (p != null) { gameObject.transform.position = new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z - 1f); }
    }


    //Allan
    // switches camera bounds to stay within the boss arena when entering the boss arena
    private void BossArenaEnter()
    {
        Debug.Log("Boss Arena Enter Bounds");
        if (BossBounds.instance != null)
        {
            gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = BossBounds.instance.gameObject.GetComponent<Collider2D>();
        }
    }

    //Allan
    // switches camera bounds to leave the boss arena when leaving
    private void BossArenaExit()
    {
        if (EndBounds.instance != null)
        {
            gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = EndBounds.instance.gameObject.GetComponent<Collider2D>();
        }
    }

    //Allan
    // unsubscribes from all events
    private void OnDestroy()
    {
        Events.Level.OnLoadedLevel -= OnLoadedLevel;
        Events.Level.OnBossArenaExit -= BossArenaExit;    
        Events.Level.BossArenaEnter -= BossArenaEnter;

    }
}
