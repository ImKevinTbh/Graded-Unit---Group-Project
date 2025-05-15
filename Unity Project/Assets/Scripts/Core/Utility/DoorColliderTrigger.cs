// code writen by allan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using EventArgs;
using Unity.Mathematics;

public class MiscController : MonoBehaviour
{
    private int range = 0;
    private int r;

    void OnTriggerEnter2D(Collider2D collider)
    {
        foreach(GameObject e in GameObject.FindGameObjectsWithTag("Layout"))
        {
            range += 1;
        }


        if (collider.gameObject.tag == "Player")
        {
            EventHandler.Level._BossArenaEnter();
            gameObject.SetActive(false);
        }
    }
}
