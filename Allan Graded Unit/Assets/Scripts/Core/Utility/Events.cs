using System;
using UnityEngine;


// as of now namespace EventArgs is depricated, not sure if can be removed rn so just leave
// ~Allan
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

    public class BossArenaEnterEventArgs
    {
        public BossArenaEnterEventArgs(GameObject instance)
        {
            Instance = instance;
        }
        public GameObject Instance { get; }
    }
}

namespace Events
{
    using EventArgs;

    // -------------------------------------------------------------------------------------------------------- //
    // ~Allan                                                                                                   //
    // For creating new events which don't absolutely need to have data passed through do the following format; //
    //                                                                                                          //
    // public class *event group name*;                                                                         //
    // {                                                                                                        //
    //      public delegate void *specific event name*();                                                       //
    //      public static event *specific event name* *variable name to listen for event*;                      //
    //                                                                                                          //
    //      public virtual void *_variablle name to trigger event*()                                            //
    //      {                                                                                                   //
    //          *_variablle name to trigger event*?.Invoke();                                                   //
    //      }                                                                                                   //
    // }                                                                                                        //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // To trigger an event from anywhere run:                                                                   //
    //                                                                                                          //
    // EventHandler.*event group name*.*_variablle name to trigger event*();                                    //
    //                                                                                                          //
    // Which will ping that event once every time it's run.                                                     //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // To listen for an event do:                                                                               //
    //                                                                                                          //
    // Events.*event group name*.*specific event name* += *function to run from event trigger*;                 //
    //                                                                                                          //
    // ...in Start function of script, then *function to run from event trigger* will run every time the event  //
    // is triggered.                                                                                            //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // If your event ABSOLUTELY NEEDS to have data passed through it amd you can't do it another way, we will   //
    // make a unique event for your purpose a different way to this.                                            //
    // -------------------------------------------------------------------------------------------------------- //


    public class Pickup
    {

        public delegate void PickupEvent();
        public static event PickupEvent OnPickup;
        public virtual void _Pickup()
        {
            OnPickup?.Invoke();
        }
    }

    public class Player
    {

        public delegate void HurtEvent();
        public static event HurtEvent Hurt;
        public virtual void _Hurt()
        {
            Hurt?.Invoke();
        }
    }


    public class Enemy
    {

        public delegate void HurtEvent();
        public static event HurtEvent Hurt;
        public virtual void _Hurt()
        {
            Hurt?.Invoke();
        }
    }

    // ~Allan
    public class Level
    {

        public delegate void BossArenaEnterEvent();
        public static event BossArenaEnterEvent BossArenaEnter;
        public virtual void _BossArenaEnter()
        {
            BossArenaEnter?.Invoke();
        }
    }
}
