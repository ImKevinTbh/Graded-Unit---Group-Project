// Code by Allan

// Don't touch this directly, inherit this script instead of MonoBehaviour in other enemy scripts

using EventArgs;
using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;


public class SkeletonEnemy : EnemyCore
{

    public void Start()
    {
        base.Start();
        Health = 3;
        Speed = 4f;
        Damage = 1;
        DistanceFromPlayer = 0f;
        Events.Enemy.Hurt += Attacked;
        rb = GetComponent<Rigidbody2D>();
        Player = PlayerController.Instance.gameObject;
        EventHandler.Enemy._spawn();

    }

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

}
