using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test script, Allan
public class Achievement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("COllider: " + collider.gameObject.name);
            EventHandler.Level._Acheivement();
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
