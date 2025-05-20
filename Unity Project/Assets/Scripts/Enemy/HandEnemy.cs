using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Events;
using EventArgs;
using MEC;
using System;


public class HandEnemy : EnemyCore
{
    

    public float HoverHeight = 3f;   // Hover 3 units above the platform
    public float BobAmplitude = 1f;  // Bob up and down by 1 unit
    public float BobFrequency = 1f;  // Bobbing speed

    private float baseY;

    //public override void Start()
    //{
    //    base.Start();
    //    Health = 3;
    //    Speed = 4f;
    //    Damage = 1;
    //    DistanceFromPlayer = 0f;
    //    Events.Enemy.Hurt += Attacked;
    //    rb = GetComponent<Rigidbody2D>();
    //    Player = PlayerController.Instance.gameObject;

    //    rb.gravityScale = 0;

    //    RaycastHit2D ground = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 25, Mask);
    //    baseY = ground.collider.transform.position.y + HoverHeight;
    //    GroundDistance += HoverHeight;
    //    EventHandler.Enemy._spawn();

    //}

    public void Update()
    {
        base.Update();
        
    }

    public void SpotPlayer()
    {

    }

    // when the player collides send a hurt event
    public void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D (collision);
        
    }

    public void OnDestroy()
    {


    }

    public void Attacked(HurtEventArgs e)
    {

    }



    void FixedUpdate()
    {
        float targetY = baseY + Mathf.Sin(Time.time * Mathf.PI * 2f * BobFrequency) * BobAmplitude;
        float currentY = transform.position.y;

        // Compute desired velocity to reach targetY
        float desiredVelocityY = (targetY - currentY) / Time.fixedDeltaTime;

        // Set vertical velocity directly, keep horizontal unchanged
        Vector3 velocity = rb.velocity;
        velocity.y = desiredVelocityY;
        rb.velocity = velocity;
    }

}
