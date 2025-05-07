using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceController : MonoBehaviour
{
    public static PersistenceController instance = null;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) { instance = this; } else { Destroy(this); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
