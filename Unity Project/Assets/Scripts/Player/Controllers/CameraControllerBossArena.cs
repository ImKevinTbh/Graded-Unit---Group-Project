// code writen by Allan 

using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using EventArgs;
using Events;

// depricated afaik // ~Allan

public class BossCameraController : MonoBehaviour
{


    private void Start()
    {
        // starts this camera inactive
        gameObject.SetActive(false);

        // checks for the player object and assisns it to the p variable


        // subscribes the door open trigger function to the boss arena enter event
        Events.Level.BossArenaEnter += doorOpenTrigger;
    }
    


    private void doorOpenTrigger()
    {
        // when the boss arena enter event is triggered this camera is enabled
        gameObject.SetActive(true);
        GetComponent<CinemachineVirtualCamera>().Follow = PlayerController.Instance.gameObject.transform;
    }
}
