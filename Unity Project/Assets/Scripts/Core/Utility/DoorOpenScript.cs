// code written by allan

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
    void Awake()
    {
        instance = this;
        Events.Level.BossArenaEnter += doorOpenTrigger;
        Events.Level.OnBossArenaExit += bossExit;
        gameObject.SetActive(false);
    }

    void doorOpenTrigger()
    {
        gameObject.SetActive(true);
    }

    void bossExit()
    {
        gameObject.SetActive(false);

    }
}
