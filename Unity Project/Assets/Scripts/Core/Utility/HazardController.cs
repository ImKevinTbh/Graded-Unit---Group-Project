using System.Collections;
using System.Collections.Generic;
using EventArgs;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
      {
        EventHandler.Player._Hurt(new HurtEventArgs(gameObject, collision.gameObject, 1));
      }
    }

}
