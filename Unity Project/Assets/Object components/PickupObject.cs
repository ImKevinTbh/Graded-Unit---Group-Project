
using UnityEngine;
using EventArgs; // Get access to eventargs
namespace Assets
{


    public class PickupObject : MonoBehaviour
    {

        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameObject.Destroy(gameObject);
                EventHandler.Pickup._Pickup(new PickupEventArgs(gameObject, other)); // Send event
            }
        }
    }
}

