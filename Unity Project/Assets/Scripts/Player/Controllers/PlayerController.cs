using System.Collections;
using System.Collections.Generic;
using EventArgs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    public int Health = 3;
    public int MaxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
            
        Events.Player.Hurt += PlayerHurt;
    }


    public void PlayerHurt(HurtEventArgs ev)
    {
        Health -= ev.Damage;

        Debug.Log($"Object: {ev.Target.name} took ({ev.Damage}) damage from source: {ev.Source.name}");
        if (Health <= 0)
        {
            EventHandler.Player._Died();
        }
    }
}
