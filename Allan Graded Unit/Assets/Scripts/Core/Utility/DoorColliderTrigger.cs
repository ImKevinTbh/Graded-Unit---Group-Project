using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using EventArgs;

public class MiscController : MonoBehaviour
{

    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EventHandler.Level._BossArenaEnter();

            Debug.Log("player entered room, door should close now");
        }
        else
        {
            Debug.Log("not the player, door should stay closed");
        }
    }

}
