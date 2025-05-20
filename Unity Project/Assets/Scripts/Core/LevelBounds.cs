using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public static LevelBounds instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Events.Level.BossArenaEnter += BossEnter;
    }

    void BossEnter()
    {
        Events.Level.BossArenaEnter -= BossEnter;
        Timing.CallDelayed(0.5f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
