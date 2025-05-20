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


    void Awake()
    {
        Events.Level.BossLayoutChange += Trigger;
    }

    
    void OnDestroy()
    {
        Events.Level.BossLayoutChange -= Trigger;
    }


    // when the Boss Layout Change event is triggered a random intiger of all the level layouts is passed through
    // in e.LayoutNumber, this is then used to select one of the layout prefabs to create in the level.
    void Trigger(BossLayoutChangeEventArgs e)
    {


        string layoutName = "Layout " + e.LayoutNumber; // Construct variable name // this works

        // cleans up previous boss arena layout
        if (e.LayoutNumber != ePrevious)
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

        foreach (GameObject target in Layouts)
        {
            if (target.name == layoutName)
            {
                Instantiate(target, new Vector2(-69.42f, 1.4f), Quaternion.identity);
            }

        }



    }

}
