using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBounds : MonoBehaviour
{
    public static EndBounds instance = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Events.Level.OnBossArenaExit += BossExit;
    }

    void BossExit()
    {
        Events.Level.BossArenaEnter -= BossExit;
        Timing.CallDelayed(0.5f, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
