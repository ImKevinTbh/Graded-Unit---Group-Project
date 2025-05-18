using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Events;
using EventArgs;


public class DenialController : MonoBehaviour
{

    public static DenialController instance;
    public List<GameObject> Deniers_1 = new List<GameObject>();
    public List<GameObject> Deniers_2 = new List<GameObject>();
    public List<GameObject> Deniers_3 = new List<GameObject>();

    public void Awake()
    {
        instance = this;
        Events.Denial.DenierDestroyed += DenierDestroyed;
    }


    public void DenierDestroyed(DenierDestroyedEventArgs ev)
    {
        Debug.Log(ev.Group + " : " + ev.Id + " Destroyed");
    }
}
