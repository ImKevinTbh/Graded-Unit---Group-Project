using Assets;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickupHandler : MonoBehaviour
{
    public static PickupHandler instance = null;
    public Events Events = new Events();


    List<string> listName = new List<string>();
    

    public List<GameObject> pickups = new List<GameObject>();
    public List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject pickupPrefab;



    private void Awake()
    {
        instance = this;
        foreach (Vector3 spawnpoint in spawnPoints)
        {
            GameObject pickup = GameObject.Instantiate(pickupPrefab);
            pickup.AddComponent<PickupObject>();
            pickup.transform.position = spawnpoint;
            Events.Pickup += PickupCollected;
        }

        
    }

    public void PickupCollected(object sender, PickupEventArgs e)
    {
        GameObject.Destroy(e.Instance);
        Debug.Log("PICKED UP");
        ScoreHandler.Score += 5;
        Debug.Log(e.Instance.transform.position);

    }


}
