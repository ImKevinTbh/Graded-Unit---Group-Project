using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //if (Instance == null) { Instance = this; } else { Destroy(this); }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
