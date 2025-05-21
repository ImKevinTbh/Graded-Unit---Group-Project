using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code by Kevin
public class DenialBoss : MonoBehaviour
{
    public static DenialBoss instance;

    public Vector2 Phase_1_SpawnPoint;
    public Vector2 Phase_2_SpawnPoint;
    public Vector2 Phase_3_SpawnPoint;

    public Vector2 FinalPhase_SpawnPoint;
    
    public Vector2 origin;
    
    public Vector2 IdlePos = new Vector2(-999, -999);

    public static bool Hit = false;
    public static bool Vulnerable = false;
    public static int Health = 10;

    public static bool CanAttack = false;
    public GameObject AttackProjectile;
    
    // Store vars
    private void Awake()
    {
        instance = this;
        gameObject.transform.position = IdlePos; // Set the enemy to its idle position, off the map
        origin = IdlePos; // Set the current stored location 
    }




    private void FixedUpdate()
    {
        var sin = Mathf.Sin(Time.time); 
        if (sin < 0) sin *= -1;
        gameObject.transform.position = new Vector3(Mathf.Lerp(origin.x - 1.75f, origin.x, sin), origin.y, transform.position.z); // Do something with a sine wave and make the character float up and down, I stole this from another project but I do not understand the math behind it
        
    }


    public void Hurt() // Runs when the bosses hurt event is run
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red; // Make Boss red red
        Health--; // Decrement health
        if (Health <= 0) // If the health is now 0
        {
            EventHandler.Denial._DenialBossKilled(); // Trigger the event to tell the rest of the scripts that the boss is dead
            EventHandler.Level._Acheivement(); // Show achievement
            NextLevel.instance.gameObject.transform.position = new Vector2(101f, -17); // Move the next level portal item into the boss room
            GameHandler.instance.Player_Unlock_Dash = true;
            Destroy(gameObject); // Destroy bossman
        }
        Timing.CallDelayed(0.25f, () => gameObject.GetComponent<SpriteRenderer>().color = Color.white); // Stop the enemy flash
    }
    public void AttackPlayer()
    {
        Instantiate(AttackProjectile, DenialBoss.instance.gameObject.transform.position, Quaternion.identity); // Spawn bullet prefab

    }

    public void OnTriggerEnter2D(Collider2D other) // When something enters the trigger collider
    {
        if (other.gameObject.CompareTag("Bullet")) // If the other object is a bullet
        {
            if (Vulnerable) // If this is marked as vulnerable
            {
                Hurt(); // Trigger hurt method
            }
            else
            {
                Hit = true; // Set hit var to true
            }

        }
    }

    public IEnumerator<float> FinalFight() // Coroutine
    {
        yield return Timing.WaitForSeconds(3f);
        CanAttack = true;
        Vulnerable = true; // Set vulnerable so the boss can be damaged properly
        
        origin = FinalPhase_SpawnPoint; // Set the stored position of the boss to the spawn point of the final phase, set in the editor 
        while (Health > 0) // while boss is not fucking dead
        {
            yield return Timing.WaitForOneFrame; // Wait for a frame so this loop does not crash the game
            var sin = Mathf.Sin(Time.time); 
            if (sin < 0) sin *= -1;
            gameObject.transform.position = new Vector3(Mathf.Lerp(origin.x - 7.75f, origin.x, sin), origin.y, transform.position.z);


            if (Random.Range(0, 100) <= 95 && CanAttack) // Make random number, if random number is above or equal to 95, continue
            {
                CanAttack = false;
                AttackPlayer(); // run attack player method
                Timing.CallDelayed(1.3f, () => CanAttack = true);
            }
            // More floaty math shit I do not understand
        }
    }
    
    
    public IEnumerator<float> Phase1() // Coroutine for first phase
    {
        Hit = false; // Set hit flag to false,
        origin = Phase_1_SpawnPoint; // Move the boss to the the Phase 1 spawn room

        while (!Hit) // while hit var is not true
        {
            yield return Timing.WaitForSeconds(1f); // Wait for 1s
            
            if (Random.Range(0, 100) <= 95) // Make random number, if random number is above or equal to 95, continue
            {
                
                AttackPlayer(); // run attack player method
            }
        }


        origin = IdlePos; // Move Boss back to idle position
        

        Destroy(GameObject.Find("Wall1")); // Destroy blocker
    }
    
    public IEnumerator<float> Phase2() // Coroutine for second phase
    {
        Hit = false; // Set hit flag to false,
        origin = Phase_2_SpawnPoint; // Move the boss to the the Phase 2 spawn room

        while (!Hit) // while hit var is not true
        {
            yield return Timing.WaitForSeconds(1f); // Wait for 1s
            
            if (Random.Range(0, 100) <= 95) // Make random number, if random number is above or equal to 95, continue
            {
                
                AttackPlayer(); // run attack player method
            }
        }


        origin = IdlePos; // Move Boss back to idle position
        

        Destroy(GameObject.Find("Wall2")); // Destroy blocker
    }
    
    public IEnumerator<float> Phase3() // Coroutine for third phase
    {
        Hit = false; // Set hit flag to false,
        origin = Phase_3_SpawnPoint; // Move the boss to the Phase 3 spawn room

        while (!Hit) // while hit var is not true
        {
            yield return Timing.WaitForSeconds(1f); // Wait for 1s
            
            if (Random.Range(0, 100) <= 95) // Make random number, if random number is above or equal to 95, continue
            {
                
                AttackPlayer(); // run attack player method
            }
        }


        origin = IdlePos; // Move Boss back to idle position
        

        Destroy(GameObject.Find("Wall3")); // Destroy blocker
    }
    
}

