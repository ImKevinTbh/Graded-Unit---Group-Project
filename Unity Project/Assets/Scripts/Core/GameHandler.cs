using Assets;
using Events;
using System;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;
using MEC;
using UnityEngine.SceneManagement;
public class GameHandler : MonoBehaviour // Kevin 
{

    /* Player Vars */
    public static bool Player_Unlock_Dash = false;

    public static bool Player_Unlock_DoubleJump = false;

    public static bool Player_Unlock_RangedAttack = false;
    /* Player Vars */
    // These will be used to store shit for the player for use in other scripts, MUST BE STATIC TO BE VISIBLE






    public static GameHandler instance = null; // Declare Instance Variable, This allows us to find THIS SPECIFIC SCRIPT without doing gameobject.find because it is performance heavy
    public GameObject Player; // Used to set the player object prefab in the editor so we can spawn them in

    private void Awake() // On Object Creation Upon Scene Load
    {
        if (instance == null) { instance = this; } else { Destroy(this); } // If an instance of this type of script already exists, destroy this one. (Should never happen)
        EventHandler.Init(); // Starts our event system (THIS NEEDS TO BE RUN BEFORE WE USE EVENTS *ANYWHERE* ELSE IN THE SOLUTION) 
        Events.Level.OnLoadedLevel += LoadedLevel; // Subscribe to the event that gets fired when a level is loaded
        Events.Player.Respawn += RespawnPlayer; // Subscribe to the event that gets fired when the player respawns
        Events.Player.OnDied += PlayerDied; // Subscribe to the event that gets fired when the player Dies
    }
    private void OnDestroy()
    {
        Events.Level.OnLoadedLevel -= LoadedLevel; // UnSubscribe to the event that gets fired when a level is loaded
        Events.Player.Respawn -= RespawnPlayer; // UnSubscribe to the event that gets fired when the player respawns
        Events.Player.OnDied -= PlayerDied; // UnSubscribe to the event that gets fired when the player Dies
    }

    public void PlayerDied()
    {
        //SceneManager.LoadScene("LevelSelect");
        // Do shit here when the player is dead
    }

    public void RespawnPlayer()
    {

        if (PlayerController.Instance != null) // Check if the player exists, should not really ever be the case
        {
            Destroy(PlayerController.Instance.gameObject);
            Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity, PersistenceController.instance.gameObject.transform); // Spawn the player
            print("Spawned player.");
            Timing.CallDelayed(0.17f, () => Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = PlayerController.Instance.gameObject.transform); // Make the camera follow the player again
        }
        else
        {
            Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity, PersistenceController.instance.gameObject.transform); // Spawn the player
            print("Spawned player.");
            Timing.CallDelayed(0.17f, () => Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = PlayerController.Instance.gameObject.transform); // Make the camera follow the player again
        }

    }

    public void LoadedLevel(LoadedLevelEventArgs ev) // The delegate method we run when LoadedLevel is run
    {
        Timing.CallDelayed(0.05f, () => 
        {
            if (PlayerController.Instance == null) // If an instance of the playercontroller script does not exist
            {
                Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity, PersistenceController.instance.gameObject.transform); // Spawn the player
                print("Spawned player.");
            }
            else // If an instance of the playercontroller script DOES exist
            {
                Debug.Log("Player exists on level load");
                PlayerController.Instance.gameObject.transform.position = MapController.Instance.InitialSpawnPoint; // Move the player to the initial spawnpoint
            }
            
            if (Settings.instance == null) { Instantiate(SettingsItem); } // If the settings object does not exist, create it, shouldn't really need to happen

            Timing.CallDelayed(0.05f, () =>
            {
                Debug.Log(PlayerController.Instance.transform.position);
                Debug.Log(MapController.Instance.InitialSpawnPoint);
                PlayerController.Instance.gameObject.transform.position = MapController.Instance.InitialSpawnPoint;
            });

        });
        

        Timing.CallDelayed(0.17f, () => Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = PlayerController.Instance.gameObject.transform); // Make the camera follow the player again
    }
}
