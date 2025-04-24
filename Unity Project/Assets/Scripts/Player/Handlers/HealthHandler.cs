using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
public class HealthHandler : MonoBehaviour
{


    public static float PlayerHealth;

    private void Awake()
    {
        EventHandler.Player.Hurt += Hurt;
    }

    public void Hurt(object sender, HurtEventArgs e)
    {
        PlayerHealth -= e.Damage;
    }
}
