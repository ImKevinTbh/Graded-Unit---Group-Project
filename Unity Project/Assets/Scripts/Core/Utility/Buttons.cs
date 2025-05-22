using EventArgs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

// all code by Allan
public class Buttons : MonoBehaviour
{
    // integer for the button number to be stored in
    private int r;

    // subscribes to events
    void Awake()
    {
        Events.Level.ButtonClick += click;
        Events.Level.LayoutComplete += changeLayout;
        gameObject.SetActive(false);
    }

    // when a button for the boss layout has been clicked, sends a boss layout change event with the buttons number and disable the buttons
    void click(ButtonClickEventArgs e)
    {
        r = e.ButtonNumber;
        EventHandler.Level._BossLayoutChangeEvent(new BossLayoutChangeEventArgs(gameObject, r));
        Timing.CallDelayed(0.1f, () => gameObject.SetActive(false));
    }

    // when the layout is to be changed enable the buttons
    void changeLayout()
    {
        gameObject.SetActive(true);
    }
}
