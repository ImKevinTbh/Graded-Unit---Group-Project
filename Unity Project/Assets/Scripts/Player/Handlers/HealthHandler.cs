using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
public class HealthHandler : MonoBehaviour
{


    public static float PlayerHealth;

    private void Awake()
    {
        Events.Player.Hurt += Hurt;
    }

    public void Hurt()
    {
        PlayerHealth -= 1;
    }
}
