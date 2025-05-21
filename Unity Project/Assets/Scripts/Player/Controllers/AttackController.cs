using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using EventArgs;
// Code by Kevin
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public int Damage;
    public static int _Damage;
    private bool canShoot = true;
    public AudioClip AudioClip;
    private bool canAttack = true;
    private LayerMask Mask;
    public Animator anim;
    public bool DetectedEnemy = false;
    public GameObject Enemy;
    public float VisionDistance = 5.0f;
    public RaycastHit2D EnemyCast;
    public float WidthScale = 1.0f;
    public Vector2 Direction = Vector2.forward;

    public virtual void Start()
    {
        Enemy = EnemyInstance.Instance.gameObject;
    }
    
    
    
    
    
    
    public void endAttack()
    {
        anim.SetBool("IsAttacking", false);
    }

    public void attack()
    {
        Debug.Log("Attack Triggered");
        Direction.x = gameObject.transform.position.x;
        RaycastHit2D HorrizontalCast = (Physics2D.Raycast(gameObject.transform.position, Direction, 1.0f * WidthScale, Mask));
        if (HorrizontalCast && HorrizontalCast.collider.gameObject == Enemy)
        {
            DetectedEnemy = true;
            Debug.Log("DetectedEnemy");
        }
        else
        {
            DetectedEnemy = false;
        }
    }


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
    



