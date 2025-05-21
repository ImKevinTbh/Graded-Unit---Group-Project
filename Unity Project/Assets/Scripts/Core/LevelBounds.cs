using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public static LevelBounds instance = null;

    // sets intance to the game object attached for easy finding and subscribes to event
    // Awake instead of Start to make sure instance is initialised in time for other scripts
    void Awake()
    {
        instance = this;
        Events.Level.BossArenaEnter += BossEnter;
    }

    // unsuscribes and sets inactive
    void BossEnter()
    {
        Events.Level.BossArenaEnter -= BossEnter;
        Timing.CallDelayed(0.5f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
