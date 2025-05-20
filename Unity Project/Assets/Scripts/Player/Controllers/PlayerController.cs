using System.Collections;
using System.Collections.Generic;
using EventArgs;
using UnityEngine;

// All code by Kevin
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    public int Health = 3;
    public int MaxHealth = 3;

    // sets Instance to itself for easy player object finding for elsewhere and subscribes to player hurt event
    void Awake()
    {
        Instance = this;
            
        Events.Player.Hurt += PlayerHurt;
    }

    // when player is hurt, health is reduced by the incoming attacks damage
    // if health hits zero trigger player died event
    public void PlayerHurt(HurtEventArgs ev)
    {
        Health -= ev.Damage;

        if (Health <= 0)
        {
            EventHandler.Player._Died();
        }
    }
}
