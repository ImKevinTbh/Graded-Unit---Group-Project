using EventArgs;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Layout : MonoBehaviour
{
    public GameObject[] Layouts;

    private GameObject selectedLayout;
    private GameObject PreviousLayout;
    private int ePrevious;
    private int i = 0;
    private int EnemyCount = 0;

    void Awake()
    {
        Events.Level.BossLayoutChange += Trigger;
        Events.Enemy.Spawn += spawn;
        Events.Enemy.OnDied += died;
    }

    
    void OnDestroy()
    {
        Events.Level.BossLayoutChange -= Trigger;
    }

    void spawn()
    {
        EnemyCount++;
        Debug.Log("Enemy Count = " + EnemyCount);

    }

    void died()
    {
        EnemyCount--;
        Debug.Log("Enemy Count = " + EnemyCount);

        if (EnemyCount == 0)
        {
            EventHandler.Level._BossLayoutChangeEvent(new BossLayoutChangeEventArgs(gameObject, 0));

        }
    }

    private void Update()
    {
    }


    // when the Boss Layout Change event is triggered a random intiger of all the level layouts is passed through
    // in e.LayoutNumber, this is then used to select one of the layout prefabs to create in the level.
    void Trigger(BossLayoutChangeEventArgs e)
    {

        i += 1;
        string layoutName = "Layout " + e.LayoutNumber; // Construct variable name // this works
        Debug.Log("Boss Layout Change Triggered, i = " + i);
        // cleans up previous boss arena layout
        if ((e.LayoutNumber != ePrevious) && i < 3)
        {
            string previousLayoutName = "Layout " + e.LayoutNumber;
            foreach (GameObject target in Layouts)
            {
                if (target.name == layoutName && target.activeInHierarchy)
                {
                    Destroy(target);

                }

            }
            ePrevious = e.LayoutNumber;
        }
        else if (i >= 3)
        {
            EventHandler.Level._BossArenaExit();
            Destroy(gameObject);
        }

        foreach (GameObject target in Layouts)
        {
            if (target.name == layoutName)
            {
                Instantiate(target, new Vector2(-69.42f, 1.4f), Quaternion.identity);
            }

        }



    }

}
