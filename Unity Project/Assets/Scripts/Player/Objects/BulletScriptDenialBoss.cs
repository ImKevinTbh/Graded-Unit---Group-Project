using UnityEngine;
using MEC;
using System;
using Unity.Collections;
using UnityEngine.Animations;
using UnityEngine.Assertions.Must;

// Code by Kevin
public class BulletScriptDenialBoss : MonoBehaviour
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
        Created = Time.time;
        GameObject pl = PlayerController.Instance.gameObject;
        target = pl.transform.position;
        GetComponent<Rigidbody2D>().AddForce(((Vector2)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);

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
        Debug.Log(collision.gameObject.name);
        
        if (!collision.gameObject == DenialBoss.instance.gameObject && !collision.gameObject.CompareTag(("Player")))
        {
            //Timing.CallDelayed(0.05f, () => Destroy(gameObject));
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(("boss shot player"));
            EventHandler.Player._Hurt(new EventArgs.HurtEventArgs(DenialBoss.instance.gameObject, PlayerController.Instance.gameObject, 1));
            Timing.CallDelayed(0.05f, () => Destroy(gameObject));
        }
        


    }



}
