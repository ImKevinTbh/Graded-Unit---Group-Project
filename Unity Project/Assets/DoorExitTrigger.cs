using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using UnityEngine.SceneManagement;

// ALl code writen by Allan


public class DoorExitTrigger : MonoBehaviour
{

    // on trigger pings boss arena exit and acheivement event
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EventHandler.Level._BossArenaExit();
            EventHandler.Level._Acheivement();
            gameObject.SetActive(false);
        }
    }
}
