using System;
using UnityEngine;
using System.Text.RegularExpressions;
using EventArgs;
using UnityEngine.SceneManagement;

// Code half and half by Kevin and Allan
namespace EventArgs
{
    // Kevin
    public class HurtEventArgs
    {
        public HurtEventArgs(GameObject source, GameObject target, int damage)
        {
            Target = target;
            Source = source;
            Damage = damage;
        }


        public GameObject Target { get; }
        public GameObject Source { get; }
        public int Damage { get; }

    }
    // Kevin
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
    // Kevin
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


    // Allan
    public class BossLayoutChangeEventArgs
    {
        public BossLayoutChangeEventArgs(GameObject instance, int layoutNumber)
        {
            LayoutNumber = layoutNumber;
        }
        public int LayoutNumber { get; }
    }

    public class ButtonClickEventArgs
    {
        public ButtonClickEventArgs(GameObject instance, int buttonNumber)
        {
            Instance = instance;
            ButtonNumber = buttonNumber;
        }
        public int ButtonNumber { get; }
        public GameObject Instance { get; }

    }
    // Kevin
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
        //public BossLayoutChangeEventArgs(GameObject instance, int layoutNumber)
      //  {
         //   LayoutNumber = layoutNumber;
       // }
       // public int LayoutNumber { get; }
    }

    public class AcheivementArgs
    {
        public AcheivementArgs(Scene level) 
        {
            Level = level;
        }

        public Scene Level { get; }
    }
}

namespace Events
{
    using EventArgs;

    // -------------------------------------------------------------------------------------------------------- //
    // ~Allan                                                                                                   //
    // For creating new events which don't  need to have data passed through do the following format;           //
    //                                                                                                          //
    //      public class *event group name*;                                                                    //
    //      {                                                                                                   //
    //          public delegate void *specific event name*();                                                   //
    //          public static event *specific event name* *variable name to listen for event*;                  //
    //                                                                                                          //
    //          public virtual void *_variablle name to trigger event*()                                        //
    //          {                                                                                               //
    //              *_variablle name to trigger event*?.Invoke();                                               //
    //          }                                                                                               //
    //      }                                                                                                   //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // To trigger an event from anywhere run:                                                                   //
    //                                                                                                          //
    //      EventHandler.*event group name*.*_variablle name to trigger event*();                               //
    //                                                                                                          //
    // Which will ping that event once every time it's run.                                                     //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // To listen for an event do:                                                                               //
    //                                                                                                          //
    //      Events.*event group name*.*specific event name* += *function to run from event trigger*;            //
    //                                                                                                          //
    // ...in Awake function of script, then *function to run from event trigger* will run every time the event  //
    // is triggered.                                                                                            //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    // If your event needs to have data passed through then you also need to include a seperate class for the   //
    // data:                                                                                                    //
    //                                                                                                          //
    //      public class *event group name*Args;                                                                //
    //      {                                                                                                   //
    //          public *event group name*Args(*Any paramiters which you want to come through*)                  //
    //          {                                                                                               //
    //              LayoutNumber = layoutNumber;                                                                //
    //          }                                                                                               //
    //          public int LayoutNumber { get; }                                                                //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    //...Then include your arguments in when you send the event:                                                //
    //                                                                                                          //
    //     EventHandler.*event group name*.*_variablle name to trigger event*(*event arguments with data type*);//
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    //...Include the event args in the event:                                                                   //
    //                                                                                                          //
    //      public class *event group name*;                                                                    //
    //      {                                                                                                   //
    //          public delegate void *specific event name*(*event group name*Args e);                           //
    //          public static event *specific event name* *variable name to listen for event*;                  //
    //                                                                                                          //
    //          public virtual void *_variablle name to trigger event*(*event group name*Args e)                //
    //          {                                                                                               //
    //              *_variablle name to trigger event*?.Invoke(e);                                              //
    //          }                                                                                               //
    //      }                                                                                                   //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    //...Finally where you listen for the event include the data type being passed through in the               //
    //                                                                                                          //
    //      Events.*event group name*.*specific event name* += *function to run from event trigger*             //
    //                                                                                                          //
    //      void *function to run frmo event trigger*(*event group name*Args e)                                 //
    //      {                                                                                                   //
    //           Something needing data += e.Whatever data type you have passed through                         //
    //      }                                                                                                   //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //
    //                                                                                                          //
    //     If that doesn't make sense look through examples already in the code                                 //
    //                                                                                                          //
    // -------------------------------------------------------------------------------------------------------- //


    public class Pickup // Kevin
    {

        public delegate void PickupEvent(PickupEventArgs e);
        public static event PickupEvent OnPickup;
        public virtual void _Pickup(PickupEventArgs e)
        {
            OnPickup?.Invoke(e);
        }
    }

    public class Game // Kevin
    {
        public delegate void QuitEvent();
        public static event QuitEvent Quit;
        public virtual void _Quit()
        {
            Quit?.Invoke();
        }
        // Kevin
        public delegate void TogglePauseEvent();
        public static event TogglePauseEvent TogglePause;
        public virtual void _TogglePause()
        {
            TogglePause?.Invoke();
        }
    }

    public class Player 
    {
        // Kevin
        public delegate void DiedEvent();
        public static event DiedEvent OnDied;
        public virtual void _Died()
        {
            OnDied?.Invoke();
        }

        // Kevin
        public delegate void HurtEvent(HurtEventArgs ev);
        public static event HurtEvent Hurt;
        public virtual void _Hurt(HurtEventArgs ev)
        {
            Hurt?.Invoke(ev);
        }
        // Kevin
        public delegate void RespawnEvent();
        public static event RespawnEvent Respawn;
        public virtual void _Respawn()
        {
            Respawn?.Invoke();
        }
        // ~Allan
        public delegate void SpawnEvent();  
        public static event SpawnEvent Spawn;
        public virtual void _spawn()
        {
            Spawn?.Invoke();
        }
    }


    public class Enemy
    {
        // Kevin
        public delegate void HurtEvent(HurtEventArgs e);
        public static event HurtEvent Hurt;
        public virtual void _Hurt(HurtEventArgs e)
        {
            Hurt?.Invoke(e);
        }
        // ~Allan
        public delegate void SpawnEvent();
        public static event SpawnEvent Spawn;
        public virtual void _spawn()
        {
            Spawn?.Invoke();
        }
        // ~Allan
        public delegate void DiedEvent();
        public static event DiedEvent OnDied;
        public virtual void _Died()
        {
            OnDied?.Invoke();
        }
    }

    public class Level
    {

        // ~Allan
        public delegate void BossArenaEnterEvent(); // ~Allan
        public static event BossArenaEnterEvent BossArenaEnter;
        public virtual void _BossArenaEnter()
        {
            BossArenaEnter?.Invoke();
            Debug.Log("Boss Arena Enter");
        }
        // ~Allan
        public delegate void BossArenaExit();
        public static event BossArenaExit OnBossArenaExit;
        public virtual void _BossArenaExit()
        {
            OnBossArenaExit?.Invoke();
        }
        // ~Allan
        public delegate void BossLayoutChangeEvent(BossLayoutChangeEventArgs e);
        public static event BossLayoutChangeEvent BossLayoutChange;
        public virtual void _BossLayoutChangeEvent(BossLayoutChangeEventArgs e)
        {
            BossLayoutChange?.Invoke(e);
            Debug.Log("Boss Layout Change");
        }
        // ~Allan
        public delegate void ButtonClickEvent(ButtonClickEventArgs e);
        public static event ButtonClickEvent ButtonClick;
        public virtual void _ButtonClickEvent(ButtonClickEventArgs e)
        {
            ButtonClick?.Invoke(e);
            Debug.Log("Button Click Event");

        }
        // Kevin
        public delegate void LoadedLevel(LoadedLevelEventArgs ev);
        public static event LoadedLevel OnLoadedLevel;
        public virtual void _LoadedLevel(LoadedLevelEventArgs ev)
        {
            OnLoadedLevel?.Invoke(ev);
        }

        // ~Allan
        public delegate void Acheivement(AcheivementArgs e);
        public static event Acheivement OnAcheivement;
        public virtual void _Acheivement(AcheivementArgs e)
        {
            OnAcheivement?.Invoke(e);
        }

        // ~Allan
        public delegate void LayoutCompleteEvent();
        public static event LayoutCompleteEvent LayoutComplete;
        public virtual void _LayoutCompete()
        {
            LayoutComplete?.Invoke();
        }
        
    }

    // Kevin
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