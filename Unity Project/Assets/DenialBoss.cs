using System.Collections;
using System.Collections.Generic;
using EventArgs;
using MEC;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Code by Kevin
public class DenialBoss : MonoBehaviour
{
    public static DenialBoss instance;

    public Vector2 Phase_1_SpawnPoint;
    public Vector2 Phase_2_SpawnPoint;
    public Vector2 Phase_3_SpawnPoint;

    public Vector2 FinalPhase_SpawnPoint;
    
    public Vector2 origin;
    
    public Vector2 IdlePos = new Vector2(-999, -999);

    public static bool Hit = false;
    public static bool Vulnerable = false;
    public static int Health = 10;

    public static bool CanAttack = false;
    public GameObject AttackProjectile;
    private void Awake()
    {
        instance = this;
        gameObject.transform.position = IdlePos;
        origin = IdlePos;
    }




    private void FixedUpdate()
    {
        var sin = Mathf.Sin(Time.time);
        if (sin < 0) sin *= -1;
        gameObject.transform.position = new Vector3(Mathf.Lerp(origin.x - 1.75f, origin.x, sin), origin.y, transform.position.z);
        
    }


    public void Hurt()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Health--;
        if (Health <= 0)
        {
            EventHandler.Denial._DenialBossKilled();
            EventHandler.Level._Acheivement();
            Destroy(gameObject);
        }
        Timing.CallDelayed(0.15f, () => gameObject.GetComponent<SpriteRenderer>().color = Color.red);
    }
    public void AttackPlayer()
    {
        Vector3 direction = gameObject.transform.position - PlayerController.Instance.transform.position;
        Instantiate(AttackProjectile, DenialBoss.instance.gameObject.transform.position, Quaternion.identity);

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

    public IEnumerator<float> FinalFight()
    {
        Vulnerable = true;
        yield return Timing.WaitForOneFrame;
        origin = FinalPhase_SpawnPoint;
        while (Health > 0)
        {
            yield return Timing.WaitForOneFrame;
            var sin = Mathf.Sin(Time.time);
            if (sin < 0) sin *= -1;
            gameObject.transform.position = new Vector3(Mathf.Lerp(origin.x - 3.75f, origin.x, sin), origin.y, transform.position.z);
            
        }
    }
    
    
    public IEnumerator<float> Phase1()
    {
        Hit = false;
        CanAttack = true;
        gameObject.transform.position = Phase_1_SpawnPoint;
        origin = transform.position;
        while (!Hit)
        {
            yield return Timing.WaitForSeconds(1f);



            if (Random.Range(0, 100) <= 98)
            {

                AttackPlayer();
            }
        }


        transform.position = IdlePos;
        origin = IdlePos;
        CanAttack = false;
        Destroy(GameObject.Find("Wall1"));
    }
    
    public IEnumerator<float> Phase2()
    {
        Hit = false;
        CanAttack = true;
        gameObject.transform.position = Phase_2_SpawnPoint;
        origin = transform.position;
        while (!Hit)
        {
            yield return Timing.WaitForSeconds(1f);



            if (Random.Range(0, 100) <= 98)
            {

                AttackPlayer();
            }
        }


        transform.position = IdlePos;
        origin = IdlePos;
        CanAttack = false;
        Destroy(GameObject.Find("Wall2"));
    }
    
    public IEnumerator<float> Phase3()
    {
        Hit = false;
        CanAttack = true;
        gameObject.transform.position = Phase_3_SpawnPoint;
        origin = transform.position;
        while (!Hit)
        {
            yield return Timing.WaitForSeconds(1f);



            if (Random.Range(0, 100) <= 98)
            {

                AttackPlayer();
            }
        }


        transform.position = IdlePos;
        origin = IdlePos;
        CanAttack = false;
        Destroy(GameObject.Find("Wall3"));
    }
    
    
}

