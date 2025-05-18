using System.Collections;
using System.Collections.Generic;
using MEC;
using Unity.VisualScripting;
using UnityEngine;

public class DenialBoss : MonoBehaviour
{
    public static DenialBoss instance;

    public Vector2 Phase_1_SpawnPoint;
    public Vector2 Phase_2_SpawnPoint;
    public Vector2 Phase_3_SpawnPoint;

    public Vector2 origin;
    
    public Vector2 IdlePos = new Vector2(-999, -999);

    public static bool Hit = false;
    public static bool Vulnerable = false;
    public static int Health = 10;

    private void Awake()
    {
        instance = this;
        gameObject.transform.position = IdlePos;
        origin = IdlePos;
    }




    private void Update()
    {
        AttackPlayer();




    }


    public void Hurt()
    {
        Health--;
    }
    public void AttackPlayer()
    {
        Vector3 direction = gameObject.transform.position - PlayerController.Instance.transform.position;
        Debug.DrawRay(transform.position, direction, Color.red, 10f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (Vulnerable)
            {
                Hurt();
            }
            else
            {
                Hit = true;
            }

        }
    }

    public IEnumerator<float> Phase1()
    {
        Hit = false;

        gameObject.transform.position = Phase_1_SpawnPoint;
        origin = transform.position;
        while (!Hit)
        {
            yield return Timing.WaitForOneFrame;


            var sin = Mathf.Sin(Time.time);
            if (sin < 0) sin *= -1;
            gameObject.transform.position = new Vector3(Mathf.Lerp(origin.x - 1.75f, origin.x, sin), Mathf.Lerp(origin.y - Random.Range(-1.74f, -1f), origin.y, sin), transform.position.z);


            if (Random.Range(0, 100) <= 85)
            {

                AttackPlayer();
            }
        }


        transform.position = IdlePos;
        origin = IdlePos;

    }
}
