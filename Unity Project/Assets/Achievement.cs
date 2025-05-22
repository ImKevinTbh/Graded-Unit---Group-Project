using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Test script, Allan
public class Achievement : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Collider: " + collider.gameObject.name);
            EventHandler.Level._Acheivement();
        }
    }
}
