using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using MEC;

public class Boss_Anger : EnemyCore
{
    public override void Start()
    {
        base.Start();
        Health = 30;
        Speed = 8f;
        Damage = 1;
    }
}
