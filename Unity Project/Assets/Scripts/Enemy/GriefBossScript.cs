using System.Collections;
using System.Collections.Generic;
using Events;
using Unity.VisualScripting;
using UnityEngine;

/* All Code Beyond This Point Has Been Written By Charlotte, Unless Stated Otherwise */
public class GriefBossScript : MonoBehaviour
{
    // These variables are used to store the default values of the bosses health, speed and damage.
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static float Damage { get; set; }

    // These are the default values for the boss.
    public void Start()
    {
        Health = 15f;
        Speed = 0.5f;
        Damage = 2f;
    }

    // When the bosses health reaches 0, it will die.
    // The destroy function allows it to die.
    private void Update()
    {
        if (Health <= 0f)
        {
            GameObject.Destroy(this.gameObject);
        }

    }

    // This code will manage the boss dealing damage to the player when they collide.
    // We use tags for this, assigning the Player a unique tag to make interactions with other things easier
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Boss Touched Player");
        }
    }
}
