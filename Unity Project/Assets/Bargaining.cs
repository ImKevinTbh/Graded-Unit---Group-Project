using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;
using static Events.Level;
using EventArgs;

// Code by Allan
public class Bargaining : MonoBehaviour
{

    public GameObject dialogue;
    private RaycastHit2D hit;
    private Vector2 playerLoaction;
    private GameObject[] bullet;

    private Vector3 startLocation;
    private Vector3 endLocation;

    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    private bool enter = true;
    // Start is called before the first frame update
    void Start()
    {
        Events.Level.BossArenaEnter += bossEnter;
        Events.Level.LayoutComplete += bossEnter;
        Events.Level.OnBossArenaExit += bossExit;
        Events.Level.BossLayoutChange += bossExitLayoutChange;

        startLocation = transform.position;
        endLocation = startLocation + new Vector3 (0, 16.0f, 0);

        startTime = Time.time;
        journeyLength = Vector3.Distance(startLocation, endLocation);
        speed = 30.0f;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (enter)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(endLocation, startLocation, fractionOfJourney);
        }

        

        if (!enter)
        {
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(startLocation, endLocation, fractionOfJourney);            
        }
    }

    void bossEnter()
    {
        gameObject.SetActive(true);
        enter = true;
        if (transform.position != startLocation)
        {
            startTime = Time.time;
        }
    }

    void bossExit()
    {
        if (transform.position != endLocation)
        {
            startTime = Time.time;
        }
        enter = false;
    }

    void bossExitLayoutChange(BossLayoutChangeEventArgs e)
    {
        if (transform.position != endLocation)
        {
            startTime = Time.time;
        }
        enter = false;
    }

}
