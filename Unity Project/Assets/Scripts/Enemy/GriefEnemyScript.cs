using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using UnityEngine;

public class GriefEnemyScript : MonoBehaviour
{
    // These variables are used to store the default values of the enemy's health, speed and damage.
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static float Damage { get; set; }

    private float DistanceFromPlayer;

    private Vector2 dir;

    // These set the starting values for the enemy
    public void Start()
    {
        Health = 50f;
        Speed = 1f;
        Damage = 1f;
        // DistanceFromPlayer is used to measure the distance between the enemy and the player
        DistanceFromPlayer = 0f;
        // Dir is used to make the boss face the player
        dir = dir = new Vector2(0, 0);
    }

    // This method manages the enemy dealing damage to the player.
    // We use tag comparison as it is a bit easier to do it that way
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // When the player touches the enemy, they will take damage.
            EventHandler.Player._Hurt(new HurtEventArgs(gameObject, this.gameObject, 1));
            Debug.Log("Enemy Touched Player");
        }
    }

    private void Update()
    {
        // DistanceFromPlayer is constantly checking for the current co-ordinates of the player
        DistanceFromPlayer = (int)(PlayerController.Instance.transform.position - transform.position).magnitude;
        // If the player is less than 35 units away from the player, the enemy will begin heading towards them.
        if (DistanceFromPlayer <= 35)
            // This tells the boss where to move
            dir = (Vector2)(PlayerController.Instance.transform.position) - (Vector2)transform.position;
        // This is intended to cap the bosses speed to a reasonable level.   
        dir.Normalize();
        // This actually makes the enemy move
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Force);

        // When the bosses health reaches 0, it will die.
        // The destroy function allows it to die.
        if (Health <= 0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // This manages the enemy recieving damage from the players attacks. Kevin created this code and I borrowed it but I wrote the comments.
    public bool Attacked(GameObject attacker, GameObject instance, float Damage)
    {
        // The enemy will change to a red colour when they take damage
        // This code retrieves the colour saved in the Sprite Renderer
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        // This actually changes the enemy's colour
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        // This will turn the enemy back to its normal colours after a short period of time.
        Timing.CallDelayed(0.2f, () =>
        {
            try
            {
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            // If something goes wrong with changing the colour back, it logs the exception/error here.
            catch (System.Exception e) { Debug.LogError(e); }
        });
        // This manages the enemy losing health by subtracting the damage from its current health.
        Health -= Damage;
        return true;
    }
}
