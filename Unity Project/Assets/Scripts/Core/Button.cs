using EventArgs;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{

    public int buttonNumber;

     void Awake()
    {
        Events.Level.BossArenaEnter += enter;
        Events.Level.ButtonClick += click;
        gameObject.SetActive(false);
        Debug.Log("Button Loaded");
    }


    void enter()
    {
        gameObject.SetActive(true);
        Debug.Log("Button Activated");
    }


    public void Clicked()
    {
        EventHandler.Level._ButtonClickEvent(new ButtonClickEventArgs(gameObject, buttonNumber));
        Debug.Log("Button Clicked " + buttonNumber);
    }


    void click(ButtonClickEventArgs e)
    {
        Debug.Log("Button Removed");
        gameObject.SetActive(false);
    }
}
