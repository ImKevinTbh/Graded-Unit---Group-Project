using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class DenialBossEnter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Timing.RunCoroutine(DenialBoss.instance.FinalFight());
            EventHandler.Level._BossArenaEnter();
        }
    }
}
