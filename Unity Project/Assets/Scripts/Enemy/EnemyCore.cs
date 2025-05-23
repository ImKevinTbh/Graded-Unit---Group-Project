using EventArgs;
using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

// All code by Allan

// Don't touch this directly, inherit this script instead of MonoBehaviour in other enemy scripts

public class EnemyCore : MonoBehaviour
{

    // As this is an inherited script all variables which could potentially be needed by various enemys are initialised here, then are inherited by other scripts

    public int Health;

    public float Speed;

    public int Damage;

    public float DistanceFromPlayer;

    public AudioClip DyingSFX;

    public Vector2 Direction = Vector2.left;

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


    // sets default variables
    public virtual void Start()
    {
        Health = 3;

        Speed = 4f;

        Damage = 1;

        DistanceFromPlayer = 0f;

        Events.Enemy.Hurt += Attacked;

        rb = GetComponent<Rigidbody2D>();
        
        color = gameObject.GetComponent<SpriteRenderer>().color;

        EventHandler.Enemy._spawn();

        Player = PlayerController.Instance.gameObject;

        gameObject.layer = LayerMask.GetMask("Enemy");

        VisionDistance = 15.0f;

}

public virtual void Update()
    {
        // when health is at or below zero, destroys the boject this script is attached to
        if (Health <= 0.0f) { GameObject.Destroy(this.gameObject); }

        // Raycasts towards the players current possition from the enemies current possition at a distance defined in VisionDistance, if no player is assigned tries to find and assign Player variable to the player
        if (Player != null)
        {
            PlayerCast = Physics2D.Raycast(gameObject.transform.position, Player.transform.position - gameObject.transform.position, VisionDistance, Mask);
        }
        else if (!Player)
        {
            Player = PlayerController.Instance.gameObject;

        }

        // if the ray collides with the player, changes the enemies direction towards the player
        if (PlayerCast && PlayerCast.collider.gameObject == Player)
        {
            SpottedPlayer = true;
            Direction.x = Player.transform.position.x - gameObject.transform.position.x;
            Direction = Direction.normalized;
            SpotPlayer();
        }
        else
        {
            SpottedPlayer = false;
        }

        // Raycasts a short distance in front of the enemy and diagonally down in front checking for walls and floors
        RaycastHit2D HorrizontalCast = (Physics2D.Raycast(gameObject.transform.position, Direction, 1.0f * WidthScale, Mask));
        RaycastHit2D DiagonalCast = (Physics2D.Raycast(gameObject.transform.position, Direction + (Vector2.down * 2), GroundDistance, Mask));

        Debug.DrawRay(gameObject.transform.position, Direction * WidthScale, Color.red);
        Debug.DrawRay(gameObject.transform.position, (Direction + (Vector2.down * 2) * GroundDistance), Color.red);

        // if either collide with a wall or floor, turns the enemy around
        if ((HorrizontalCast || !DiagonalCast) && Movement) 
        {
            Direction *= -1;
            Vector2 scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
        }


        Vector2 vel = rb.velocity; // We cant modify velocity directly on a single axis so copy it to a variable
        vel.x = Mathf.Clamp(rb.velocity.x, -Speed, Speed); //  Stop going too fast by using the clamp method and giving it min/max parameters

        rb.velocity = vel; // Now set the velocity back to whatever we had in the variable
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
        
    }


    // here for inheritable functionality
    public virtual void SpotPlayer()
    {

    }

    // when the player collides send a hurt event
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventHandler.Player._Hurt(new HurtEventArgs(this.gameObject, collision.gameObject, Damage));
            Debug.Log("Player Hurt Event Triggered from" + gameObject.name);
        }
    }

    // on destroy unsubscribes from events and pings enemy died event
    public virtual void OnDestroy()
    {
        Events.Enemy.Hurt -= Attacked;
        ScoreHandler.Score += 10;
        EventHandler.Enemy._Died();
    }

    // when enemy hurt is pinged sets enemy colour to red for 0.2 seconds then back to the origional colour, then reduces health by damage
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
