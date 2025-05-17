using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using MEC;
using Unity.VisualScripting;
using UnityEngine;

/* All Code Beyond This Point Has Been Written By Charlotte, Unless Stated Otherwise */
public class GriefBossScript : MonoBehaviour
{
    // These variables are used to store the default values of the bosses health, speed and damage.
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static float Damage { get; set; }

    public float cooldown;

    public GameObject EnemyBullet;

    private float DistanceFromPlayer;
    
    private float timer;

    private Vector2 dir;

    // These are the default values for the boss.
    public void Start()
    {
        Health = 150f;
        Speed = 0.5f;
        Damage = 2f;
        // DistanceFromPlayer is used to measure the distance between the enemy and the player
        DistanceFromPlayer = 0f;
        // Timer is used to manage how often the boss shoots a bullet at the player
        timer = 0;
        // Dir is used to make the boss face the player
        dir = new Vector2(0, 0);

    }

    private void Update()
    {
        // DistanceFromPlayer is constantly checking for the current co-ordinates of the player
        DistanceFromPlayer = (int)(GameObject.Find("Player(Clone)").transform.position - transform.position).magnitude;
        // If the player is less than 35 units away from the player, the enemy will begin heading towards them.
        if (DistanceFromPlayer <= 35)
        // This tells the boss where to move
            dir = (Vector2)(GameObject.Find("Player(Clone)").transform.position) - (Vector2)transform.position;
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

        // This will spawn the bullet once a short cooldown ends
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            // Once the bullet is fired, the cooldown resets.
            timer = 0;
            // Instantiate is used to create the bullet
            Instantiate(EnemyBullet, transform.position, transform.rotation);
        }
    }

    // This code will manage the boss dealing damage to the player when they collide.
    // We use tags for this, assigning the Player a unique tag to make interactions with other things easier
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Boss Touched Player");
        }
    }

    // This manages the boss recieving damage from the players attacks. Kevin created this code and I borrowed it but I wrote the comments.
    public bool Attacked(GameObject attacker, GameObject instance, float Damage)
    {
        // The boss will change to a red colour when they take damage
        // This code retrieves the colour saved in the Sprite Renderer
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        // This actually changes the bosses colour
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        // This will turn the boss back to its normal colours after a short period of time.
        Timing.CallDelayed(0.2f, () =>
        {
            try
            {
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            // If something goes wrong with changing the colour back, it logs the exception/error here.
            catch (Exception e) { Debug.LogError(e); }
        });

        // This manages the boss losing health by subtracting the damage from its current health.
        Health -= Damage;
        return true;
    }
}
