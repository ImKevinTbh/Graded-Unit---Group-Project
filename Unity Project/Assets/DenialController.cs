using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Events;
using EventArgs;
using MEC;

// Code by Kevin
public class DenialController : MonoBehaviour
{

    public static DenialController instance;
    public List<GameObject> DenialObjects = new List<GameObject>(); // Store deniers

    public int Group_1 = 2;
    public int Group_2 = 3;
    public int Group_3 = 3;
// Keep count of denier objects
    public void Awake()
    {
        instance = this;
        Events.Denial.DenierDestroyed += DenierDestroyed; // Subscribe event
    }


    public void BossPhase1() // First phase action
    {
        Debug.LogWarning("Boss Phase 1");

        Timing.RunCoroutine(DenialBoss.instance.Phase1());
    }
    public void BossPhase2() // Second phase action
    {
        Debug.LogWarning("Boss Phase 2");
        Timing.RunCoroutine(DenialBoss.instance.Phase2());

    }
    public void BossPhase3()  // Third phase action
    {
        Debug.LogWarning("Boss Phase 3");
        Timing.RunCoroutine(DenialBoss.instance.Phase3());
    }

    public void DenierDestroyed(DenierDestroyedEventArgs ev)  // Run when a denier is destroyed
    {
        Debug.Log(ev.Group + " : " + ev.Id + " Destroyed");
        DenialObjects.Remove(ev.Instance.gameObject);  // Remove denier from object list
        switch (ev.Group)
        {
            case 1:
                {
                    Group_1--;

                    if (Group_1 == 0) { BossPhase1(); }  
                    break;
                }
            case 2:
                {
                    Group_2--;

                    if (Group_2 == 0) { BossPhase2(); }
                    break;
                }
            case 3:
                {
                    Group_3--;

                    if (Group_3 == 0) { BossPhase3(); }
                    break;
                }
        }
    }
}
