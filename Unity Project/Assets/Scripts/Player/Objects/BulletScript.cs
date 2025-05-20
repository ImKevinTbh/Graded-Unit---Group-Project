using UnityEngine;
using MEC;
using System;
using Unity.Collections;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;
using EventArgs;
public class BulletScript : MonoBehaviour
{
    public int Damage;
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    public float pushBackForce = 2000f;
    private Vector2 target;

    void Awake()
    {
        Damage = AttackController._Damage;
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


    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { return; }
        else if (collision.CompareTag("Boundary") || collision.CompareTag("Camera Boundary")) { return; }
        else
        {
            if (collision.CompareTag("Enemy"))
            {
                EventHandler.Enemy._Hurt(new HurtEventArgs(gameObject, collision.gameObject, Damage));
                Debug.Log($"Object Collided: {collision.gameObject} IN BULLET SCRIPT");
            }
            Debug.LogWarning(collision.gameObject.name);
            Timing.CallDelayed(0.05f, () => Destroy(gameObject)); 
        }
        collision = null; // this added because the collision keeps the previous object type sometimes,
                          // I dont know why this could be and I no longer care ~ Allan
    }

}
