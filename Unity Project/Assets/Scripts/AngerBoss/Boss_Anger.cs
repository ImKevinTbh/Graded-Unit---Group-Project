using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using MEC;

public class Boss_Anger : EnemyCore
{
    public static bool CanAttack = false;
    public GameObject HellbentAngerBossSpectralSword;
    public override void Start()
    {
        base.Start();
        Health = 30;
        Speed = 10f;
        Damage = 1;
    }

    public void AttackPlayer()
    {
        Vector3 direction = gameObject.transform.position - PlayerController.Instance.transform.position;
        Instantiate(HellbentAngerBossSpectralSword, gameObject.transform.position, Quaternion.identity);

    }
}
