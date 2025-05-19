using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceController : MonoBehaviour
{
    public static PersistenceController instance = null;
    public GameObject SettingsItem;
    public List<GameObject> Objects = new List<GameObject>();
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Objects.Add(gameObject);
        }
        if (instance == null) { instance = this; } else { Destroy(this); }
        if (Settings.instance == null) { Instantiate(SettingsItem); } // If the settings object does not exist, create it, shouldn't really need to happen
        Events.Game.Quit += Quit;
    }

    public void Quit()
    {

        foreach (GameObject o in Objects)
        {
            Debug.Log(o.name);
            Destroy(o);
        }

    }
}
