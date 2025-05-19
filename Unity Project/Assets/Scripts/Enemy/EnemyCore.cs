using EventArgs;
using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static float Damage { get; set; }

    public float DistanceFromPlayer;

    public AudioClip DyingSFX;


    public void Start() 
    {
        Health = 100f;
        Speed = 1.5f;
        Damage = 1.0f;
        DistanceFromPlayer = 0f;
    }

    private void Update()
    {
        if (Health <= 0.0f) { GameObject.Destroy(this.gameObject); }
        if (PlayerController.Instance != null)
        {
            DistanceFromPlayer = (int)(PlayerController.Instance.gameObject.transform.position - transform.position).magnitude;
            gameObject.GetComponent<Rigidbody2D>().AddForce(PlayerController.Instance.gameObject.transform.position - gameObject.transform.position, ForceMode2D.Force);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerController.Instance.gameObject)
        {
            Debug.LogWarning("Hit the fucking player");
            EventHandler.Player._Hurt(new HurtEventArgs(collision.gameObject, this.gameObject, 1));
        }
    }

    public void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(DyingSFX, gameObject.transform.position);
        Destroy(gameObject);
        ScoreHandler.Score += 10;
    }

    public bool Attacked(GameObject attacker, GameObject instance, float Damage)
    {

        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        Timing.CallDelayed(0.2f, () =>
        {
            try
            {
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            catch (Exception e) { Debug.LogError(e); }
        });

        Health -= Damage;
        return true;
    }

}
