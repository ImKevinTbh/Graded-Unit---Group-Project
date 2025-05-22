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
}