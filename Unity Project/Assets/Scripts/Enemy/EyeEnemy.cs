using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//uses Events;
using EventArgs;
using MEC;
using System;


public class EyeEnemy : EnemyCore
{
    public float HoverHeight = 3f;   // Hover 3 units above the platform
    public float BobAmplitude = 1f;  // Bob up and down by 1 unit
    public float BobFrequency = 1f;  // Bobbing speed

    private float baseY;

    public override void Start()
    {
        baseY = 10;
        base.Start();
        rb.gravityScale = 0;

        RaycastHit2D ground = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 25, Mask);
        baseY = ground.collider.transform.position.y + HoverHeight;
        GroundDistance += HoverHeight;
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
