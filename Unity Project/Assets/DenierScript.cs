using System.Collections;
using System.Collections.Generic;
using EventArgs;
using Unity.VisualScripting;
using UnityEngine;

// Code by Kevin
public class DenierScript : MonoBehaviour
{
    public int Group;
    public int Id;
    // Start is called before the first frame update

    private void Awake()
    {
        DenialController.instance.DenialObjects.Add(gameObject); // Add this object to the list of gameobjects in the DenialController script
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Check if collision is a bullet by tag
        {
            Debug.Log("Hit");
            Destroy(gameObject); // Destroy the gameobject this script is attached to
        }
    }

    private void OnDestroy()
    {
        EventHandler.Denial._DenierDestroyed(new DenierDestroyedEventArgs(gameObject, Group, Id)); // Call the DenierDestroyed event
    }
}
