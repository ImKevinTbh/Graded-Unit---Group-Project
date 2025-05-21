using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public int Health = 3;
    public int MaxHealth = 3;

    private Vector2 PreviousTempPossition;
    private Vector2 CurrentTempPossition;
    private Vector2 CurrentTempDirection;
    private Vector2 Direction;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
            
        Events.Player.Hurt += PlayerHurt;

    }

    private void Update()
    {

    }

    public void PlayerHurt(HurtEventArgs ev)
    {
        if (Settings.instance.CheatMode)
        {
            return;}
        
        Health -= ev.Damage;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;




        Timing.CallDelayed(0.25f, () => gameObject.GetComponent<SpriteRenderer>().color = Color.white);
        Debug.Log($"Object: {ev.Target.name} took ({ev.Damage}) damage from source: {ev.Source.name}");
        
        
        
        if (Health <= 0)
        {
            Debug.LogWarning("Player Died");
            EventHandler.Player._Died();
        }
    }
}
