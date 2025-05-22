using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;

// Code by Kevin(?)

// Possiblly depricated
public class HealthHandler : MonoBehaviour
{


    public static float PlayerHealth;

    private void Awake()
    {
        Events.Player.Hurt += Hurt;
    }

    public void Hurt(HurtEventArgs e)
    {
        PlayerHealth -= 1;
    }
}
