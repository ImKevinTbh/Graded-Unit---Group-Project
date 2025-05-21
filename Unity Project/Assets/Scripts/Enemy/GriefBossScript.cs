using System;
using System.Collections;
using System.Collections.Generic;
using EventArgs;
using Events;
using MEC;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/* All Code Beyond This Point Has Been Written By Charlotte, Unless Stated Otherwise */
public class GriefBossScript : EnemyCore
{
    // These variables are used to store the default values of the bosses health, speed and damage.

    public Vector2 dir;

    public static float Damage { get; set; }

    public float cooldown;

    public GameObject EnemyBullet;
    
    private float timer;

    // These are the default values for the boss.
    public void Start()
    {
        base.Start();
        Health = 5f;
        Speed = 0.5f;
        Damage = 2f;
        // DistanceFromPlayer is used to measure the distance between the enemy and the player
        DistanceFromPlayer = 0f;
        // Timer is used to manage how often the boss shoots a bullet at the player
        timer = 0;
    }

    // This method is used to control anything in the script that needs to be constantly checked, like the movement.
    private void Update()
    {
        Debug.Log(Health);
        Movement();
        // This will spawn the bullet once a short cooldown ends
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            // Once the bullet is fired, the cooldown resets.
            timer = 0;
            // Instantiate is used to create the bullet
            Instantiate(EnemyBullet, transform.position, transform.rotation);
        }

        // When the bosses health reaches 0, it will die.
        // The destroy function allows it to die.
        if (Health == 0f) { Debug.Log("Dead"); Destroy(this.gameObject); }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // When the player touches the boss, they will take damage.
            EventHandler.Player._Hurt(new HurtEventArgs(gameObject, this.gameObject, 1));
            Debug.Log("Boss Touched Player");
        }
    }

    public void Movement()
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
    }
}
