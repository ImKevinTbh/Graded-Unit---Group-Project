
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
            if (other.CompareTag("Boundary") || other.CompareTag("Bullet") || other.CompareTag("Pickup")) { return; }
            GameObject.Destroy(gameObject);
            Events.OnPickup(new PickupEventArgs(gameObject, other));
        }
    }
}

