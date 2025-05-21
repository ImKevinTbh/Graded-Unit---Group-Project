using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using EventArgs;
using Unity.Mathematics;

// code writen by allan

public class MiscController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EventHandler.Level._BossArenaEnter();
            gameObject.SetActive(false);
        }
    }
}
