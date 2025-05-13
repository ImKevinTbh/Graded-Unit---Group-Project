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

    //public class BossArenaEnterEventArgs
    //{
    //    public BossArenaEnterEventArgs(GameObject instance)
    //    {
    //        Instance = instance;
    //    }
    //    public GameObject Instance { get; }
    //}

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


    public class Pickup
    {

        public delegate void PickupEvent(PickupEventArgs e);
        public static event PickupEvent OnPickup;
        public virtual void _Pickup(PickupEventArgs e)
        {
            OnPickup?.Invoke(e);
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

        public delegate void BossLayoutChangeEvent(BossLayoutChangeEventArgs e);
        public static event BossLayoutChangeEvent BossLayoutChange;
        public virtual void _BossLayoutChangeEvent(BossLayoutChangeEventArgs e)
        {
            BossLayoutChange?.Invoke(e);
        }

        public delegate void ButtonClickEvent(ButtonClickEventArgs e);
        public static event ButtonClickEvent ButtonClick;
        public virtual void _ButtonClickEvent(ButtonClickEventArgs e)
        {
            ButtonClick?.Invoke(e);
        }

        //Lilith

        




    }
    public class Hazards
    {
        public delegate void HazardTriggerEvent();
        public static event HazardTriggerEvent HazardTrigger;
        
        public virtual void _Hazards ()
        {
            HazardTrigger?.Invoke();
        }
    }
}

