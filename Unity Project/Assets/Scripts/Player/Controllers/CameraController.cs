using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using EventArgs;
using Events;

public class CameraController : MonoBehaviour
{


    public static CameraController instance = null;

    // initialises variable to hold player reference
    public GameObject p;


    private void Start()
    {

        instance = this;

        // checks for the player object and assisns it to the p variable
        p = GameObject.Find("PlayerModel").gameObject;

        // subscribes the door open trigger function to the boss arena enter event
        Events.Level.BossArenaEnter += doorOpenTrigger;
    }


    private void Update()
    {
        // every frame moves the cameras possition to focus on the player
        gameObject.transform.position = new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z - 1f);
    }


    private void doorOpenTrigger()
    {
        // when the boss arena enter event is triggered this camera is enabled
        gameObject.SetActive(false);
    }
}
