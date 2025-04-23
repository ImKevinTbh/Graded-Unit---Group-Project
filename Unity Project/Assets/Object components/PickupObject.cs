
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets
{


    public class PickupObject : MonoBehaviour
    {
        public Events Events = PickupHandler.instance.Events;

        public void OnTriggerEnter2D(Collider2D other)
        {
            Events.OnPickup(new PickupEventArgs(other));
        }
    }
}

