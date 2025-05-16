
using EventArgs;
using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyCore : MonoBehaviour
{
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static float Damage { get; set; }

    public float DistanceFromPlayer;

    public AudioClip DyingSFX;

    public Vector2 Direction = Vector2.left;

    public LayerMask Mask;

    private Rigidbody2D rb;
    
    private bool SpottedPlayer = false;

    public GameObject Player;

    public float VisionDistance = 5.0f;


    public void Start()
    {
        Health = 100f;
        Speed = 4f;
        Damage = 1.0f;
        DistanceFromPlayer = 0f;
        Events.Enemy.Hurt += Attacked;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Health <= 0.0f) { GameObject.Destroy(this.gameObject); }

        // Raycasts towards the players current possition from the enemies current possition at a distance defined in VisionDistance
        RaycastHit2D PlayerCast = Physics2D.Raycast(gameObject.transform.position, Player.transform.position - gameObject.transform.position, VisionDistance, Mask);


        // if the ray collides with the player, changes the enemies direction towards the player
        if (PlayerCast && PlayerCast.collider.gameObject == Player)
        {
            SpottedPlayer = true;
            Direction.x = Player.transform.position.x - gameObject.transform.position.x;
            Direction = Direction.normalized;
        }
        else
        {
            SpottedPlayer = false;
        }

        // Raycasts a short distance in front of the enemy and diagonally down in front checking for walls and floors
        RaycastHit2D HorrizontalCast = (Physics2D.Raycast(gameObject.transform.position, Direction, 1.0f, Mask));
        RaycastHit2D DiagonalCast = (Physics2D.Raycast(gameObject.transform.position, Direction + Vector2.down, 2, Mask));

        // if either collide with a wall or floor, turns the enemy around
        if (HorrizontalCast || !DiagonalCast) 
        {
                Direction = Direction * -1;
        }


        Vector2 vel = rb.velocity; // We cant modify velocity directly on a single axis so copy it to a variable
        vel.x = Mathf.Clamp(rb.velocity.x, -Speed, Speed); //  Stop going too fast by using the clamp method and giving it min/max parameters

        rb.velocity = vel; // Now set the velocity back to whatever we had in the variable
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
        

    }

    private void SpotPlayer()
    {

    }

    // when the player collides send a hurt event
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == Player)
        {
            EventHandler.Player._Hurt(new HurtEventArgs(this.gameObject, collision.gameObject, Damage));
        }
    }

    public void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(DyingSFX, gameObject.transform.position);
        Events.Enemy.Hurt -= Attacked;
        Destroy(gameObject);
        ScoreHandler.Score += 10;
    }

    public void Attacked(HurtEventArgs e)
    {

        Color color = gameObject.GetComponent<SpriteRenderer>().color;
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
