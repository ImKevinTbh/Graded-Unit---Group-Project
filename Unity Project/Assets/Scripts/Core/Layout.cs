using EventArgs;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Layout : MonoBehaviour
{
    public GameObject[] Layouts;

    [SerializeField] private GameObject layout;
    [SerializeField] private GameObject PreviousLayout;
    [SerializeField] private int ePrevious;
    [SerializeField] private int i = 0;
    [SerializeField] private int EnemyCount = 0;
    [SerializeField] private string layoutName;
    [SerializeField] private string previousLayoutName;

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

    }

    void died()
    {
        EnemyCount--;

        if (i >= 3 && EnemyCount == 0)
        {
            EventHandler.Level._BossArenaExit();
            Destroy(gameObject);
            return;
        }
        else if (EnemyCount == 0)
        {
            EventHandler.Level._LayoutCompete();
        }
        
    }


    // when the Boss Layout Change event is triggered a random intiger of all the level layouts is passed through
    // in e.LayoutNumber, this is then used to select one of the layout prefabs to create in the level.
    void Trigger(BossLayoutChangeEventArgs e)
    {
        
        i += 1;
        
        string layoutName = "Layout " + e.LayoutNumber; // Construct variable name // this works

        // cleans up previous boss arena layout
        if (layout)
        {
            Destroy(layout);
        }
        
        

        foreach (GameObject target in Layouts)
        {
            if (target.name == layoutName)
            {
                layout = Instantiate(target, new Vector2(-69.42f, 1.4f), Quaternion.identity);
            }

        }

    }

}
