using Assets;
using Events;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using EventArgs;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance = null;


    private void Start()
    {
        if (instance == null) { instance = this; } else { Destroy(this); }
        EventHandler.Init();
    }

}
