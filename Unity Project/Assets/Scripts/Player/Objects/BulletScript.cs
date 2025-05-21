using UnityEngine;
using MEC;
using System;
using Unity.Collections;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;
using EventArgs;

//ALl code writen by Kevin
public class BulletScript : MonoBehaviour
{
    public int Damage;
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    public float pushBackForce = 2000f;
    private Vector3 target;

    void Awake()
    {
        Damage = AttackController._Damage;
        Created = Time.time;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().AddForce(((Vector3)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);
        GameObject pl = GameObject.Find("PlayerModel");

    }

    void Update()
    {
        Vector2 dir = (target - gameObject.transform.position);
        //rotation script written by Lilith
        // this script rotates the bullet to face forward after firing, no matter the direction the player is facing
        //TL/DR fancy maths makes the pointy bit rotate to face away from the player
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //end of rotation script


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
            }
            Timing.CallDelayed(0.05f, () => Destroy(gameObject)); 
        }
        collision = null; // this added because the collision keeps the previous object type sometimes,
                          // I dont know why this could be and I no longer care ~ Allan
    }

}
