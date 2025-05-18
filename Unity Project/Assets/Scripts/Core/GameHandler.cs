
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;
using Events;
using MEC;
public class GameHandler : MonoBehaviour // Kevin 
{
    public static GameHandler instance = null; // Declare Instance Variable, This allows us to find THIS SPECIFIC SCRIPT without doing gameobject.find because it is performance heavy
    public GameObject Player; // Used to set the player object prefab in the editor so we can spawn them in

    private void Start() // On Object Creation Upon Scene Load
    {
        if (instance == null) { instance = this; } else { Destroy(this); } // If an instance of this type of script already exists, destroy this one. (Should never happen)
        EventHandler.Init(); // Starts our event system (THIS NEEDS TO BE RUN BEFORE WE USE EVENTS *ANYWHERE* ELSE IN THE SOLUTION) 
        Events.Level.OnLoadedLevel += LoadedLevel; // Subscribe to the event that gets fired when a level is loaded
        Events.Player.Respawn += RespawnPlayer;
    }


    public void RespawnPlayer()
    {

        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.gameObject.transform.position = MapController.Instance.InitialSpawnPoint;
            PlayerController.Instance.Health = PlayerController.Instance.MaxHealth;
        }
        else
        {
            Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity, PersistenceController.instance.gameObject.transform); // Spawn the player
            print("Spawned player.");
        }

    }

    public void LoadedLevel(LoadedLevelEventArgs ev) // The delegate method we run when LoadedLevel is run
    {
        Debug.Log("GameHandler: Level Loaded");
        Timing.CallDelayed(0.15f, () => 
        {
            if (PlayerController.Instance == null) // If an instance of the playercontroller script does not exist
            {
                Instantiate(Player, MapController.Instance.InitialSpawnPoint, Quaternion.identity, PersistenceController.instance.gameObject.transform); // Spawn the player
                print("Spawned player.");
            }
            else // If an instance of the playercontroller script DOES exist
            {
                PlayerController.Instance.gameObject.transform.position = MapController.Instance.InitialSpawnPoint; // Move the player to the initial spawnpoint
            }


        });
        

        Timing.CallDelayed(0.17f, () => Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Follow = PlayerController.Instance.gameObject.transform); // Make the camera follow the player again
    }
}
