using UnityEngine;
using MEC;
using System;
using Unity.Collections;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;
public class BulletScript : MonoBehaviour
{
    public float Damage;
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    public float pushBackForce = 2000f;
    private Vector2 target;

    void Awake()
    {
        Damage = AttackController._Damage;
        Debug.Log($"{Damage}");
        Created = Time.time;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().AddForce(((Vector2)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);
        GameObject pl = GameObject.Find("PlayerModel");
        
    }

    void Update()
    {
        if (Time.time < Created + LifeTime)
        {

        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { return; }
        else if (collision.CompareTag("Boundary")) { return; }
        else
        {
            if (collision.gameObject.GetComponent<EnemyCore>() != null)
            {
                Debug.Log($"ENEMY WAS SHOT AND TRIGGER ENTERED WITH {Damage} DAMAGE");
                collision.gameObject.GetComponent<EnemyCore>().Attacked(this.gameObject, collision.gameObject, Damage);
            }
            Timing.CallDelayed(0.01f, () => Destroy(gameObject));
        }

    }



}
