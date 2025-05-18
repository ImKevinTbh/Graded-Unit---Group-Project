using System;
using System.Text.RegularExpressions;
using EventArgs;
using UnityEngine;

namespace EventArgs
{
    public class HurtEventArgs
    {
        public HurtEventArgs(GameObject target, GameObject source, int damage)
        {
            Target = target;
            Source = source;
            Damage = damage;
        }

        public GameObject Target { get; }
        public GameObject Source { get; }
        public int Damage { get; }
    }

    public class DenierDestroyedEventArgs
    {
        public DenierDestroyedEventArgs(GameObject instance, int group, int id)
        {
            Instance = instance;
            Group = group;
            Id = id;
        }
        public GameObject Instance { get; }
        public int Group { get; }
        public int Id { get; }

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

    public class LoadedLevelEventArgs
    {
        public LoadedLevelEventArgs(MapController instance)
        {
            Instance = instance;
        }

        public MapController Instance { get; }
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

        public delegate void PickupEvent(PickupEventArgs ev);
        public static event PickupEvent OnPickup;
        public virtual void _Pickup(PickupEventArgs ev)
        {
            OnPickup?.Invoke(ev);
        }
    }

    public class Player
    {

        public delegate void HurtEvent(HurtEventArgs ev);
        public static event HurtEvent Hurt;
        public virtual void _Hurt(HurtEventArgs ev)
        {
            Hurt?.Invoke(ev);
        }

        public delegate void RespawnEvent();
        public static event RespawnEvent Respawn;
        public virtual void _Respawn()
        {
            Respawn?.Invoke();
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

        public delegate void LoadedLevel(LoadedLevelEventArgs ev);
        public static event LoadedLevel OnLoadedLevel;
        public virtual void _LoadedLevel(LoadedLevelEventArgs ev)
        {
            OnLoadedLevel?.Invoke(ev);
        }


        public delegate void BossArenaEnterEvent();
        public static event BossArenaEnterEvent BossArenaEnter;
        public virtual void _BossArenaEnter()
        {
            BossArenaEnter?.Invoke();
        }
    }

    public class Denial
    {
        public delegate void DenierDestroyedEvent(DenierDestroyedEventArgs ev);
        public static event DenierDestroyedEvent DenierDestroyed;
        public virtual void _DenierDestroyed(DenierDestroyedEventArgs ev)
        {
            DenierDestroyed?.Invoke(ev);
        }
    }
}



