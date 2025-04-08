using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public static float Health { get; set; }
    public static float Speed { get; set;}
    public static float Damage { get; set;}

    public float DistanceFromPlayer;

    public AudioClip DyingSFX;


    public void Start()
    {
        Health = 100f;
        Speed = 5f;
        Damage = 1.0f;
        DistanceFromPlayer = 0f;
    }

    private void Update()
    {
        if (Health <= 0.0f) { GameObject.Destroy(this.gameObject); }
        DistanceFromPlayer = (int)(GameObject.Find("PlayerModel").transform.position - transform.position).magnitude;
        gameObject.GetComponent<Rigidbody2D>().AddForce(GameObject.Find("PlayerModel").transform.position - gameObject.transform.position, ForceMode2D.Force);
    }

    public void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(DyingSFX, gameObject.transform.position);
        Destroy(gameObject);
    }

    public bool Attacked(GameObject attacker, GameObject instance, float Damage)
    {

        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        try
        {
            Timing.CallDelayed(0.2f, () => { gameObject.GetComponent<SpriteRenderer>().color = color; });

        }
        catch (Exception e)
        {

        }

        Debug.Log($"Old {Health}");
        Health -= Damage;
        Debug.Log($"New {Health}");
        return true;
    }

}
