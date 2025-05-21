using System;
using System.Collections;
using System.Collections.Generic;
// We use the events system here - Lilith
using EventArgs;
using Events;
using MEC;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/* All Code Beyond This Point Has Been Written By Charlotte, Unless Stated Otherwise */
public class GriefBossScript : EnemyCore
{
    // These variables are used to store the default values of the bosses health, speed and damage
    // Variables Updated By Lilith
    public float cooldown;

    public GameObject EnemyBullet;
    
    private float timer;

    private Vector2 dir;

    public int Health;

    public float Speed;

    public int Damage;

    public float DistanceFromPlayer;

    public AudioClip DyingSFX;

    public LayerMask Mask;

    public Rigidbody2D rb;

    public bool SpottedPlayer = false;

    public GameObject Player;

    public float VisionDistance = 5.0f;

    public float GroundDistance = 2.0f;

    public float WidthScale = 1.0f;

    public bool Movement = true;

    public Color color;

    public int i = 0;

    public RaycastHit2D PlayerCast;


    // These are the default values for the boss.
    //Sets Health, Speed and damage, initialises certain methods for colour change, Damage Dealing and Player Tracking - Lilith
    public virtual void Start()
    {
        Health = 30;

        Speed = 8f;

        Damage = 1;

        DistanceFromPlayer = 0f;

        Events.Enemy.Hurt += Attacked;

        rb = GetComponent<Rigidbody2D>();

        color = gameObject.GetComponent<SpriteRenderer>().color;

        EventHandler.Enemy._spawn();

        Player = PlayerController.Instance.gameObject;

        // DistanceFromPlayer is used to measure the distance between the enemy and the player
        DistanceFromPlayer = 0f;
        // Timer is used to manage how often the boss shoots a bullet at the player
        timer = 0;
        // Dir is used to make the boss face the player 
        dir = new Vector2(0, 0);
    }

    // This method is used to control anything in the script that needs to be constantly checked, like the movement.
    private void Update()
    {
        Anim.speed = 0.4f;
        Debug.Log(this.Health);
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
        if (this.Health <= 0.0f) { Events.Enemy.Hurt -= Attacked; Events.Enemy.Hurt += base.Attacked; Destroy(this.gameObject); }
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

    // Moved To This Script by Lilith// //This method manages the boss recieving damage from the players attacks. Kevin created this code and I borrowed it but I wrote the comments. - Allan
    public virtual void Attacked(HurtEventArgs e)
    {

        if (e.Target.GetInstanceID() == gameObject.GetInstanceID())
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            Timing.CallDelayed(0.2f, () =>
            {
                try
                {
                    gameObject.GetComponent<SpriteRenderer>().color = color;
                }
                catch (Exception e) { }
            });

            Health -= Damage;
        }
    }
}
