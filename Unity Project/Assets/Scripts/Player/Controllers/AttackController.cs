using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using MEC;
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public int Damage;
    public static int _Damage;
    private bool canShoot = true;
    public AudioClip AudioClip;
    void Update()
    {
        _Damage = Damage;
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            if (canShoot)
            {
                canShoot = false;
                Instantiate(bullet, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(AudioClip, PlayerController.Instance.transform.position);
                Timing.CallDelayed(0.14f, () => canShoot = true);
            }
            
        }
    }


}
