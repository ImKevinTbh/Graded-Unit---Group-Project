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
    }


    void enter()
    {
        gameObject.SetActive(true);
    }


    public void Clicked()
    {
        EventHandler.Level._ButtonClickEvent(new ButtonClickEventArgs(gameObject, buttonNumber));
    }


    void click(ButtonClickEventArgs e)
    {
        gameObject.SetActive(false);
    }
}
