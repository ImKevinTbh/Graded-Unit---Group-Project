using System;
using UnityEngine;

namespace EventArgs
{
    public class HurtEventArgs
    {
        public HurtEventArgs(GameObject instance, GameObject source, float damage)
        {
            Instance = instance;
            Source = source;
            Damage = damage;
        }

        public GameObject Instance { get; }
        public GameObject Source { get; }
        public float Damage { get; }
    }

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
}

namespace Events
{
    using EventArgs;

    public class Pickup
    {


        public event EventHandler<PickupEventArgs> OnPickup;
        public virtual void _Pickup(PickupEventArgs pickupeventargs)
        {
            OnPickup?.Invoke(this, pickupeventargs);
        }
    }

    public class Player
    {
        public event EventHandler<HurtEventArgs> Hurt;
        public virtual void _Hurt(HurtEventArgs playerhurteventargs)
        {
            Hurt?.Invoke(this, playerhurteventargs);
        }
    }


    public class Enemy
    {
        public event EventHandler<HurtEventArgs> Hurt;
        public virtual void _Hurt(HurtEventArgs playerhurteventargs)
        {
            Hurt?.Invoke(this, playerhurteventargs);
        }
    }
}


