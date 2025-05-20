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

    public override void Start()
    {
        base.Start();
        Health = 3;
        Speed = 4f;
        Damage = 1;
    }
}
