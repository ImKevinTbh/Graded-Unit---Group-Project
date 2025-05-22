using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using MEC;

public class Boss_Anger : EnemyCore
{
    public static Boss_Anger instance;
    public static bool CanAttack = false;
    public GameObject SpectralSword;
    
    
    public override void Start()
    {
        base.Start();
        Health = 15;
        Speed = 10f;
        Damage = 1;
        Events.Enemy.Hurt += Attacked;
    }

    public void AttackPlayer()
    {
        Instantiate(SpectralSword, Boss_Anger.instance.gameObject.transform.position, Quaternion.identity); // Spawn bullet prefab

    }

    public void update()
    {
        if (Random.Range(0, 100) <= 98)
        {
            AttackPlayer();
        }
    }

    public virtual void Attacked()
    {
        Debug.Log("Boss Hurt");
        if (Health <= 0) // If the health is now 0
        {
            Debug.Log("0 Health Detected");
            NextLevel3.instance.gameObject.transform.position = new Vector2(9, 147); // Move the next level portal item into the boss room

        }

    }
}
