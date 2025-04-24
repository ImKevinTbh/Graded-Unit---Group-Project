
using UnityEngine;
using EventArgs; // Get access to eventargs
namespace Assets
{


    public class PickupObject : MonoBehaviour
    {


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Boundary") || other.CompareTag("Bullet") || other.CompareTag("Pickup")) { return; }
            GameObject.Destroy(gameObject);
            EventHandler.Pickup._Pickup(new PickupEventArgs(gameObject, other)); // Send event
        }
    }
}

