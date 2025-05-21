using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventArgs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code by Kevin
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
            Objects.Add(gameObject.transform.GetChild(i).gameObject);
        }
        if (instance == null) { instance = this; } else { Destroy(this); }
        if (Settings.instance == null) { Instantiate(SettingsItem).gameObject.transform.parent = gameObject.transform; } // If the settings object does not exist, create it, shouldn't really need to happen
        Events.Level.OnLoadedLevel += LoadedLevel;
        Events.Player.OnDied += Died;

    }

    public void LoadedLevel(LoadedLevelEventArgs ev)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (Objects.Contains(gameObject.transform.GetChild(i).gameObject))
            {
                
                Objects.Add(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }

    public void Died()
    {

        SceneManager.LoadScene("DeathScene");


        Destroy(this.gameObject);
    }
}
