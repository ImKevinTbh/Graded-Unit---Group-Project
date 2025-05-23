using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinLoseCon : MonoBehaviour
{
    // These are the global variables being defined
    private GameObject Boss;
    private GameObject Player;
    private float time;
    private PlayerController script;

    // Start is called before the first frame update
    // These are defining the defaults for the variables that will be used later on in the script
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("GriefBoss");
        Player = PlayerController.Instance.gameObject;
        time = 0f;
        script = PlayerController.Instance;
         
    }

    // Update is called once per frame
    void Update()
    {
        // The variables are now assigned default values.
        // Boss is used to identify the boss by finding its unique tag
        Boss = GameObject.FindGameObjectWithTag("GriefBoss");
        // Player serves a similar function as Boss but instead looks for a unique player tag.
        Player = GameObject.FindGameObjectWithTag("Player");
        // time basically counts up with the time.
        // It cannot be uppercase like the rest as Time is an actual function in Unity.
        time += Time.deltaTime;
        // Script is used to call the PlayerController script.
        script = PlayerController.Instance;

        // This method triggers when the boss is killed.
        if (Boss == null)
        {
            // When the boss no longer exists, it will take the player to the win screen!
            Debug.Log("The Boss is Dead.");
            SceneManager.LoadScene("WinScene");
        }

        // This method will trigger when the player has been alive for at least a second and has reached zero health
        //if (time >= 1f && PlayerController.Instance.Health <= 0)
        //{
        //    Debug.Log("Dead.");
        //    EventHandler.Game._Quit();
        //}
    }
}
