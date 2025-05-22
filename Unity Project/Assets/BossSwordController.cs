using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs;
using MEC;

public class BossSwordController : MonoBehaviour
{
    public int Damage;
    // Start is called before the first frame update
    public virtual void Start()
    {
        Damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventHandler.Player._Hurt(new HurtEventArgs(this.gameObject, collision.gameObject, Damage));
        }
    }

    
}
