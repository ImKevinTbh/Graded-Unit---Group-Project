using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lilith
public class OnPlayerTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collision2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            transform.position = new Vector2(0f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
      {
        Debug.Log ("we hit");
      }
    }

}
