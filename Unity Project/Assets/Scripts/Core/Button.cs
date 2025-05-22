using EventArgs;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// All code by Allan
public class Button : MonoBehaviour
{
    // button number set in editor
    public int buttonNumber;
    private bool reEnable = true;

    // subscribes to event and sets inactive
     void Awake()
    {
        Events.Level.BossArenaEnter += enter;
        Events.Level.ButtonClick += clicked;
        gameObject.SetActive(false);
    }

    // when player enters boss arena buttons are enabled
    void enter()
    {
        if (reEnable)
        {
            gameObject.SetActive(true);
        }
    }

    void clicked(ButtonClickEventArgs e)
    {

        if (e.ButtonNumber == buttonNumber)
        {
            Debug.Log("button number: " + e.ButtonNumber + " from: " + buttonNumber);
            Destroy(gameObject);
        }
    }



    // the button which is clicked sends a button click event with it's number attached
    public void Clicked()
    {
        EventHandler.Level._ButtonClickEvent(new ButtonClickEventArgs(gameObject, buttonNumber));
        Debug.Log("Button Clicked Event");
    }


}
