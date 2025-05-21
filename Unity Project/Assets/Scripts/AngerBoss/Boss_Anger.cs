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
        Health = 30;
        Speed = 10f;
        Damage = 1;
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
    
}
