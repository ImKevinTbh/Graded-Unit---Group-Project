using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using EventArgs;

public class DoorOpenScript : MonoBehaviour
{

    public static DoorOpenScript instance = null;
    //public Events Events = new Events();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Events.Level.BossArenaEnter += doorOpenTrigger;
        gameObject.SetActive(false);
    }

    void doorOpenTrigger()
    {
        Debug.Log("the script to close the door got the event so this shit is just broken");
        gameObject.SetActive(true);
    }
}
