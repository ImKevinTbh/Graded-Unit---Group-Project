using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using MEC;


// Code by Allan
public class BossBounds : MonoBehaviour
{
    public static BossBounds instance = null;

    // sets intance to the game object attached for easy finding and subscribes to event
    void Start()
    {
        instance = this;
        Events.Level.OnBossArenaExit += BossExit;
    }

    // unsubscribes and sets itself inactive after a delay
    void BossExit()
    {
        Events.Level.OnBossArenaExit -= BossExit;
        Timing.CallDelayed(0.5f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
