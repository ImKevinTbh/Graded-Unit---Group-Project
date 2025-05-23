using System;
using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using UnityEngine;

public class GriefEnemyScript : EnemyCore
{
    // These variables are used to store the default values of the enemy's health, speed and damage. 

    private Vector2 dir;

    private Animator Anim;

    public override void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        base.Start();
        Events.Enemy.Hurt += Attacked;
        EventHandler.Enemy._spawn();
    }



    public void OnDestroy()
    {
        Events.Enemy.Hurt -= Attacked;
    }

    // These set the starting values for the enemy
    private void Update()
    {
        Debug.Log(this.Health);
        Anim.speed = 0.4f;
        Movement();

        // When the bosses health reaches 0, it will die.
        // The destroy function allows it to die.
        if (this.Health <= 0.0f) { Events.Enemy.Hurt -= this.Attacked; Destroy(this.gameObject); }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // When the player touches the enemy, they will take damage.
            EventHandler.Player._Hurt(new HurtEventArgs(gameObject, this.gameObject, 1));
            Debug.Log("Enemy Touched Player");
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



    public override void Attacked(HurtEventArgs e)
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

            this.Health -= this.Damage;
        }
    }
}
