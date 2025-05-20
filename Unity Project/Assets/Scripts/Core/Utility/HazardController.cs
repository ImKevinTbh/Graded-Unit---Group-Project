using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lilith
public class OnPlayerTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(GetComponent.gameObject.tag== "Ground"<Collider2D>(), GetComponent<Collider2D>());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2( 0f, 0.5f) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
      {
        Debug.Log ("we hit");
      }
    }

}
