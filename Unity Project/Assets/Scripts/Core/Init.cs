using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
public class Init : MonoBehaviour
{
    public GameObject CoreObjects;
    void Start()
    {
        if (GameHandler.instance == null)
        {
            Instantiate(CoreObjects, Vector3.zero, Quaternion.identity);
        }
        Timing.CallDelayed(0.5f, () => MapController.Instance.Init());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
