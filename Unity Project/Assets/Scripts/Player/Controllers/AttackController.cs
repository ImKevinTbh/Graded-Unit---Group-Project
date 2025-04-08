using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using MEC;
public class AttackController : MonoBehaviour
{
    public GameObject bullet;
    public float Damage;
    public static float _Damage;
    private bool canShoot = true;
    public AudioClip AudioClip;
    void Update()
    {
        _Damage = Damage;
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Timing.RunCoroutine(Shoot().CancelWith(gameObject));
            AudioSource.PlayClipAtPoint(AudioClip, GameObject.Find("PlayerModel").gameObject.transform.position);
        }
    }

    public IEnumerator<float> Shoot()
    {
        canShoot = false;
        Instantiate(bullet, transform.position, transform.rotation);
        yield return Timing.WaitForSeconds(0.15f);
        canShoot = true;
        
    }


}
