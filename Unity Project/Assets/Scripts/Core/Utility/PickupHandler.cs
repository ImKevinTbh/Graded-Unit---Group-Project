using Assets;
using Events;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;

public class PickupHandler : MonoBehaviour
{
    public static PickupHandler instance = null;

    public List<GameObject> pickups = new List<GameObject>();
    public List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject pickupPrefab;



    private void Start()
    {
        Events.Pickup.OnPickup += PickupCollected; // Subscribe to event, all events should be under "EventHandler.<Category>.On<EventName>

        foreach (Vector3 spawnpoint in spawnPoints)
        {
            GameObject pickup = GameObject.Instantiate(pickupPrefab);
            pickup.transform.position = spawnpoint;
            pickups.Add(pickup);
        }


    }

    private void OnDisable()
    {
        Events.Pickup.OnPickup -= PickupCollected; // Unsubscribe event, stops the event being registered multiple times on restarts and stuff
    }

    public void PickupCollected(PickupEventArgs ev)
    {
        pickups.Remove(ev.Instance.gameObject);
        Debug.Log("PICKED UP");
        ScoreHandler.Score += 5;

    }


}
