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

    // subscribes to event and sets inactive
     void Awake()
    {
        Events.Level.BossArenaEnter += enter;
        gameObject.SetActive(false);
    }

    // when player enters boss arena buttons are enabled
    void enter()
    {
        gameObject.SetActive(true);
    }

    // the button which is clicked sends a button click event with it's number attached
    public void Clicked()
    {
        EventHandler.Level._ButtonClickEvent(new ButtonClickEventArgs(gameObject, buttonNumber));
    }


}
