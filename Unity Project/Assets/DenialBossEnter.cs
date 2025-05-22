using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using UnityEngine;

public class DenialBossEnter : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) // if colliding object is the player
        {
            Timing.RunCoroutine(DenialBoss.instance.FinalFight()); // Trigger the final fight coroutine in the denial boss script
            EventHandler.Level._BossArenaEnter(); // Trigger the bossarenaenter event
        }
    }
}
