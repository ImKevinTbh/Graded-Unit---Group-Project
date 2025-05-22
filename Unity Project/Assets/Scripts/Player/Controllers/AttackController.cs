using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using EventArgs;
using Unity.Burst.CompilerServices;
using static UnityEngine.RuleTile.TilingRuleOutput;
// Code by Kevin
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public int Damage;
    public static int _Damage;
    private bool canShoot = true;
    public AudioClip AudioClip;
    private bool canAttack = true;
    public LayerMask Mask;
    public Animator anim;
    public float SwingDistance = 4.5f;
    //public RaycastHit2D[] hit;

    public Vector2 Direction = Vector2.left;

    public static Collider2D[] hit;

    public virtual void Start()
    {
        _Damage = Damage;
        Mask = LayerMask.GetMask("Enemy");

        
    }

    // unity animation calls endAttack on the frame the player attack animation ends
    public void endAttack()
    {
        anim.SetBool("IsAttacking", false);
        canAttack = true;
    }

    // unity animation calls attack on the frame the player attack animation will visually collide with the enemy
    public void attack()
    {
        hit = Physics2D.OverlapBoxAll(gameObject.transform.position + (new Vector3(MovementHandler.instance.direction, 0.3f, 0) * SwingDistance / 2), new Vector2(SwingDistance / 2, SwingDistance), 0.0f, Mask);
        foreach (Collider2D enemy in hit)
        {
            if (enemy != null && enemy.gameObject.CompareTag("Enemy"))
            {
                try { Debug.Log("Collider collided with melee: " + enemy.name); } catch { Debug.Log("Collider collided with melee: NULL"); }

                EventHandler.Enemy._Hurt(new HurtEventArgs(gameObject, enemy.gameObject, 1));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(gameObject.transform.position + (new Vector3(MovementHandler.instance.direction, 0.3f, 0) * SwingDistance / 2), new Vector2(SwingDistance / 2, SwingDistance));
    }

    void Update()
    {

        
        



        Debug.DrawRay(transform.position, new Vector2(MovementHandler.instance.direction, 0) * SwingDistance, Color.red);

        if (Input.GetKey(KeyCode.Mouse1) && canShoot && GameHandler.instance.Player_Unlock_RangedAttack)
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(bullet, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(AudioClip, PlayerController.Instance.transform.position);
                Timing.CallDelayed(0.7f, () => canShoot = true);

            }

        }


        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            anim.SetBool("IsAttacking", true);            
            
        }

    }

}
