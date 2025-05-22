using System.Collections;
using System.Collections.Generic;
using EventArgs;
using UnityEngine;
/* All code below this point has been written by Charlotte, unless stated otherwise */

public class EnemyBulletScript : MonoBehaviour
{
    // Defining initial variables to be used in the script
    private GameObject player;
    private Rigidbody2D bull;
    public float speed;
    public float lifeTime;
    private float Pass;

    // Start is called before the first frame update
    // This will define the initial values/states of each variable
    void Start()
    {
        // Pass represents the lifetime of the bullet
        Pass = 0;
        // bull is the variable for the enemy's bullet
        bull = GetComponent<Rigidbody2D>();
        // This tells the enemy what it is shooting at
        player = GameObject.FindGameObjectWithTag("Player"); 
        // This code defines where the bullet will shoot
        Vector3 direction = player.transform.position - transform.position;
        bull.velocity = new Vector2(direction.x, direction.y).normalized * speed;

    }

    // Update is called once per frame
    void Update()
    {
        // Pass will update as the bullet exists
        Pass += Time.deltaTime;
        // Once the bullet has been alive longer than the max lifetime, it will despawn and reset the Pass value
        if (Pass > lifeTime)
        {
            Pass = 0;
            GameObject.Destroy(gameObject);
        }
    }

    // This allows the enemy to hurt the player using an event handler created by Kevin
    void OnTriggerEnter2D(Collider2D hit)
    {
        // This code checks if the player has been hit.
        // If the player is not hit, it breaks free of the collision;
        if (!hit.CompareTag("Player"))
        {
            return;
        }
        else
        {
            // If the bullet hits the player, it will deal damage to them.
            EventHandler.Player._Hurt(new HurtEventArgs(hit.gameObject, this.gameObject, 1));
        }
    }
}
