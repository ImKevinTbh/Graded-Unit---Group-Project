using System.Collections;
using System.Collections.Generic;
using EventArgs;
using Unity.VisualScripting;
using UnityEngine;

public class DenierScript : MonoBehaviour
{
    public int Group;
    public int Id;
    // Start is called before the first frame update

    private void Awake()
    {
        DenialController.instance.DenialObjects.Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EventHandler.Denial._DenierDestroyed(new DenierDestroyedEventArgs(gameObject, Group, Id));
    }
}
