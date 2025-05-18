using System.Collections;
using System.Collections.Generic;
using EventArgs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance = null;

    public static int Health = 3;



    public int Score = 0;
    
    public bool DoubleJump_Unlock = false;
    public bool Ranged_Unlock = false;
    public bool Dash_Unlock = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Events.Player.Hurt += PlayerHurt;
    }
    
    
    public void PlayerHurt(HurtEventArgs ev)
    {
        Health -= ev.Damage;
        Debug.Log(Health);
    }
}


