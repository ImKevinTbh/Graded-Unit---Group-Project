using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using MEC;

public class Boss_Anger : EnemyCore
{
    public static bool CanAttack = false;
    public GameObject AttackProjectile;
    public override void Start()
    {
        base.Start();
        Health = 30;
        Speed = 10f;
        Damage = 1;
    }
}
