using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;
using EventArgs;
using UnityEngine.SceneManagement;
using MEC;

// All code done by Allan
public class AchievementHandler : MonoBehaviour
{

    public Sprite Default;
    public Sprite Limbo;
    public Sprite Grief;
    public Sprite Denial;
    public Sprite Anger;
    public Sprite Bargaining;
    public Sprite Depression;
    public Sprite Acceptance;
    private Sprite sprite;
    private float heightMax = -337.7621f;
    private float heightMin = -494.5f;
    private bool hitTop = false;
    private bool moveDown = false;
    private Color clear = Color.clear;
    private Color white = Color.white;
    
    // subscribes to acheivement event sets default variables
    void Start()
    {
        Events.Level.OnAcheivement += Acheivement;
        string test = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
        sprite = GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<SpriteRenderer>().color = clear;
    }

    //          EventHandler.Level._Acheivement(new AcheivementArgs(SceneManager.GetActiveScene()));
    //          To ping event

    // checks each level and sets its sprite depending
    // also slowly moves up into frame from the bottom right, holds for 5 seconds, then slowly moves back down out of frame
    void Acheivement(AcheivementArgs e)
    {
        if (gameObject.transform.position.y < heightMax && !hitTop)
        {
            gameObject.transform.position += Vector3.up * 2.8f;
        }
        else if (hitTop)
        {
            Timing.CallDelayed(5.0f, () => moveDown = true);
        }
        else if (moveDown)
        {
            gameObject.transform.position -= Vector3.up * 10;
        }
        else if (gameObject.transform.position.y < heightMin)
        {
            gameObject.GetComponent<SpriteRenderer>().color = clear;
            moveDown = false;
            hitTop = false;
        }

        if (e.Level.name == "Limbo")
        {
            sprite = Limbo;
            gameObject.GetComponent<SpriteRenderer>().color = white;
        }
        else if (e.Level.name == "Grief")
        {
            sprite = Grief;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else if (e.Level.name == "Denial")
        {
            sprite = Denial;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else if (e.Level.name == "Anger")
        {
            sprite = Anger;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else if (e.Level.name == "Bargaining")
        {
            sprite = Bargaining;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else if (e.Level.name == "Depression")
        {
            sprite = Depression;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else if (e.Level.name == "Acceptance")
        {
            sprite = Acceptance;
            gameObject.GetComponent<SpriteRenderer>().color = white;

        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = clear;
            sprite = Default;

        }
    }
}
