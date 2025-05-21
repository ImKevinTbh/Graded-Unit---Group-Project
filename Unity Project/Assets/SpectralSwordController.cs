using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralSwordController : MonoBehaviour
{
    public float Damage;
    public float Created;
    public float LifeTime;
    public float bSpeed = 1;
    public float pushBackForce = 2000f;
    private Vector2 target;

   //// void Awake()
 //   {
   //     Damage = AttackController._Damage;
   //     Created = Time.time;
   //     GameObject pl = PlayerController.Instance.gameObject;
    //    target = pl.transform.position;
    //    GetComponent<Rigidbody2D>().AddForce(((Vector2)gameObject.transform.position - target).normalized * bSpeed * -Vector2.one);

  //  }

  //  void Update()
  //  {
  //      if (Time.time < Created + LifeTime)
   //     {

   //     }
    //    else
    //    {
   //         GameObject.Destroy(gameObject);
   //     }
  //  }

  //  void OnTriggerEnter2D(Collider2D collision)
  //  {
  //      if (collision.gameObject == Boss_Anger.instance.gameObject) { return; }
  //      if (collision.CompareTag("Player"))
 //       {
   //         EventHandler.Player._Hurt(new EventArgs.HurtEventArgs(PlayerController.Instance.gameObject, Boss_Anger.instance.gameObject, 1));

  //      }
        //Timing.CallDelayed(0.05f, () => Destroy(gameObject));
   // }
}
