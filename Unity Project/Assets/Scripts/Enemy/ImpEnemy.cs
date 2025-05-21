using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using UnityEngine;

public class ImpEnemy : EnemyCore
{
    public override void Start()
    {
        base.Start();
        Health = 5;
        Speed = 3f;
        Damage = 1;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // When the player collides with the enemy, it will deal damage to the player
            EventHandler.Player._Hurt(new HurtEventArgs(gameObject, this.gameObject, 1));
            Debug.Log("Enemy Touched Player");
        }
    }
}