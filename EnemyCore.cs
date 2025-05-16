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


        RaycastHit2D PlayerCast = Physics2D.Raycast(gameObject.transform.position, Player.transform.position - gameObject.transform.position, VisionDistance, Mask);

        if (PlayerCast && PlayerCast.collider.gameObject == Player)
        {
            SpottedPlayer = true;
            Debug.Log("Starting Tracking Player");
            Direction.x = Player.transform.position.x - gameObject.transform.position.x;
            Direction = Direction.normalized;
        }
        else
        {
            SpottedPlayer = false;
            Debug.Log("Stopping Tracking Player");
            try { Debug.Log("PlayerCast Result: " + PlayerCast.collider.gameObject); } catch { Debug.Log("PlayerCast Result: NULL" ); }
        }

        RaycastHit2D HorrizontalCast = (Physics2D.Raycast(gameObject.transform.position, Direction, 1.0f, Mask));
        RaycastHit2D DiagonalCast = (Physics2D.Raycast(gameObject.transform.position, Direction + Vector2.down, 2, Mask));

        if (HorrizontalCast || !DiagonalCast) 
        {
                Direction = Direction * -1;
        }


        Vector2 vel = rb.velocity; // We cant modify velocity directly on a single axis so copy it to a variable
        vel.x = Mathf.Clamp(rb.velocity.x, -Speed, Speed); //  Stop going too fast by using the clamp method and giving it min/max parameters

        rb.velocity = vel; // Now set the velocity back to whatever we had in the variable
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
        
        
        Debug.DrawRay(gameObject.transform.position, (Player.transform.position - gameObject.transform.position).normalized * VisionDistance, Color.red);





    }

    private void SpotPlayer()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
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
