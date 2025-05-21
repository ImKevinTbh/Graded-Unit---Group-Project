using EventArgs;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using MEC;


//All code writen by Allan
public class Layout : MonoBehaviour
{
    public GameObject[] Layouts;

    private GameObject layout;
    private GameObject PreviousLayout;
    private int ePrevious;
    public int iterations = 3;
    private int EnemyCount = 0;
    private string layoutName;
    private string previousLayoutName;
    public static Layout instance;

    // subscribes to events
    void Awake()
    {
        instance = this;
        Events.Level.BossLayoutChange += Trigger;
        Events.Enemy.Spawn += spawn;
        Events.Enemy.OnDied += died;
        iterations = 3;
    }

    //unsubscribes from events
    void OnDestroy()
    {
        Events.Level.BossLayoutChange -= Trigger;
        Events.Enemy.Spawn -= spawn;
        Events.Enemy.OnDied -= died;
    }

    // when an enemy spawns increase the enemy count by 1
    void spawn()
    {
        EnemyCount++;
    }

    // when an enemy dies decrease the enemy count by 1
    void died()
    {
        EnemyCount--;
        Debug.Log("EnemyCount " + EnemyCount);

        // if there have been 3 boss room iterations & there are no enemies left, destroy this object and trigger boss arena exit event
        if (iterations <= 0 && EnemyCount == 0)
        {
            EventHandler.Level._BossArenaExit();
            Destroy(gameObject);
            return;
        }
        // if there have been less than 3 iterations then ping completed layout event to create options to start another elsewhere
        else if (EnemyCount == 0)
        {

            // cleans up previous boss arena layout
            if (layout)
            {
                Timing.CallDelayed(1.5f, () => Destroy(layout));
                Timing.CallDelayed(0.5f, () => EventHandler.Level._LayoutCompete());
            }
        }
    }


    // when the Boss Layout Change event is triggered a random intiger of all the level layouts is passed through
    // in e.LayoutNumber, this is then used to select one of the layout prefabs to create in the level.
    void Trigger(BossLayoutChangeEventArgs e)
    {
        Debug.Log("Iterations " + iterations);
        iterations -= 1;
        
        layoutName = "Layout " + e.LayoutNumber; // Construct variable name 
        
        // checks through all layouts in the layouts array and spawns the one with the matching number to the option selected
        foreach (GameObject target in Layouts)
        {
            if (target.name == layoutName)
            {
                layout = Instantiate(target, new Vector2(-69.42f, 1.4f), Quaternion.identity);
            }

        }

    }

}
