using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

// Code by Allan
public class Bargaining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Events.Level.BossArenaEnter += bossEnter;
        Events.Level.LayoutComplete += layoutComplete;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void bossEnter()
    {

    }

    void layoutComplete()
    {

    }
}
