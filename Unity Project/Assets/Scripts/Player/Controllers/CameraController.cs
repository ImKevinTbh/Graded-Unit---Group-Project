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

    // initialises variable to hold player reference
    public GameObject p;
    public Collider2D LevelCameraBounds;
    public Collider2D BossCameraBounds;
    public Collider2D EndLevelCameraBounds;

    public static CameraController instance; // Do not remove, needed for movement controller.



    private void Awake()
    {
        instance = this; // Do not remove, needed for movement controller.

        // checks for the player object and assisns it to the p variable
        p = GameObject.Find("PlayerModel").gameObject;

        gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = LevelCameraBounds;

        // subscribes the door open trigger function to the boss arena enter event
        Events.Level.BossArenaEnter += BossArenaEnter;

        //Events.Level.BossArenaLeave += BossArenaLeave;    //TBA//
		
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

    // switches camera bounds to stay within the boss arena when entering the boss arena
    private void BossArenaEnter()
    {
        gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = BossCameraBounds;

    }

    // switches camera bounds to leave the boss arena when leaving
    private void BossArenaLeave()
    {
        gameObject.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = EndLevelCameraBounds;
	}
	
}
