using System;
using UnityEngine;

public class PickupEventArgs
{
    public PickupEventArgs(GameObject instance, Collider2D collider)
    {
       Instance = instance;
       Collider = collider;
    }
    public GameObject Instance { get; }
    public Collider2D Collider { get; }

}

public class PlayerHurtEventArgs
{
    public PlayerHurtEventArgs(GameObject instance, GameObject source, float damage)
    {
       Instance = instance;
       Source = source;
       Damage = damage;
    }

    public GameObject Instance { get; }
    public GameObject Source { get; }
    public float Damage { get; }
}

public class Events
{
    public event EventHandler<PickupEventArgs> Pickup;
    public virtual void OnPickup(PickupEventArgs pickupeventargs)
    {
        Pickup?.Invoke(this, pickupeventargs);
    }

    public event EventHandler<PlayerHurtEventArgs> PlayerHurt;
    public virtual void OnPlayerHurt(PlayerHurtEventArgs playerhurteventargs)
    {
        PlayerHurt?.Invoke(this, playerhurteventargs);
    }
}