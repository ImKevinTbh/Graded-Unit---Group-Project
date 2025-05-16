using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceController : MonoBehaviour
{
    public static PersistenceController instance = null;
    public GameObject SettingsItem;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) { instance = this; } else { Destroy(this); }
        if (Settings.instance == null) { Instantiate(SettingsItem); } // If the settings object does not exist, create it, shouldn't really need to happen
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
