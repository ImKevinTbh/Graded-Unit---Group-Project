using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public int Damage;
    public static int _Damage;
    private bool canShoot = true;
    public AudioClip AudioClip;
    private bool canAttack = true;
    private LayerMask mask;
    public Animator anim;
    void Update()
    {
        _Damage = Damage;
        if (Input.GetKey(KeyCode.Mouse1) && canShoot)
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(bullet, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(AudioClip, PlayerController.Instance.transform.position);
                Timing.CallDelayed(0.14f, () => canShoot = true);
            }
            
        }
        
        _Damage = Damage;
        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            anim.SetBool("IsAttacking", true);


            Timing.CallDelayed(1f, () => { canAttack = true; anim.SetBool("IsAttacking", false); });


        }

        }
    }



