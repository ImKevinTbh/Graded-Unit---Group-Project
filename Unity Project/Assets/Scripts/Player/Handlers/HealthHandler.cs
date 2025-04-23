using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public static HealthHandler instance = null;
    public Events Events = new Events();

    public static float PlayerHealth;

    private void Awake()
    {
        Events.PlayerHurt += Hurt;
    }

    public void Hurt(object sender, PlayerHurtEventArgs e)
    {
        PlayerHealth -= e.Damage;
    }
}
