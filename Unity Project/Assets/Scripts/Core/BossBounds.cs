using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using MEC;

public class BossBounds : MonoBehaviour
{
    public static BossBounds instance = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Events.Level.OnBossArenaExit += BossExit;
    }


    void BossExit()
    {
        Events.Level.OnBossArenaExit -= BossExit;
        Timing.CallDelayed(0.5f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
