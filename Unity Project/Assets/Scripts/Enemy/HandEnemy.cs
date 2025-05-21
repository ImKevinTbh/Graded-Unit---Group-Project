using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Events;
using EventArgs;
using MEC;
using System;

// All code by Allan
public class HandEnemy : EnemyCore
{
    
    // inherits EnemyCore sript for most functionality

    public float HoverHeight = 3f;   // Default height to hover above the ground
    public float BobAmplitude = 1f;  // the varience in hover height to give a bob
    public float BobFrequency = 1f;  // bobbing speed

    private float baseY;

    // initialises variables
    public override void Start()
    {
        base.Start();
        rb.gravityScale = 0;

        RaycastHit2D ground = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 25, Mask);
        baseY = ground.collider.transform.position.y + HoverHeight;
        GroundDistance += HoverHeight;
    }


    // uses a sine wave to move up and down around a fixed y possition
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
