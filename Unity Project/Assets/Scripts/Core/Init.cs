using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

// Code by Kevin
public class Init : MonoBehaviour
{
    public GameObject CoreObjects;
    void Start()
    {
        if (GameHandler.instance == null) // Check if gamehandler already exists
        {
            Instantiate(CoreObjects, Vector3.zero, Quaternion.identity); // If not, spawn the core objects
        }
        Timing.CallDelayed(0.5f, () => MapController.Instance.Init()); // Run init script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
