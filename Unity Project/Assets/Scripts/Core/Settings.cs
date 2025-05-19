using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance = null;

    public bool CheatMode = false;
    
    void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(this.gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
