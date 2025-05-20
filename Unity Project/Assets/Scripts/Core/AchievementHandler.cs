using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;
using EventArgs;
using UnityEngine.SceneManagement;


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
    private float transparency = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Events.Level.OnAcheivement += Acheivement;
        string test = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(gameObject);
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    //          EventHandler.Level._Acheivement(new AcheivementArgs(SceneManager.GetActiveScene()));
    //          To ping event


    void Acheivement(AcheivementArgs e)
    {
        if (e.Level.name == "Limbo")
        {
            sprite = Limbo;
        }
        else if (e.Level.name == "Grief")
        {
            sprite = Grief;
        }
        else if(e.Level.name == "Denial")
        {
            sprite = Denial;
        }
        else if (e.Level.name == "Anger")
        {
            sprite = Anger;
        }
        else if (e.Level.name == "Bargaining")
        {
            sprite = Bargaining; 
        }
        else if (e.Level.name == "Depression")
        {
            sprite = Depression;
        }
        else if (e.Level.name == "Acceptance")
        {
            sprite = Acceptance;
        }
        else
        {
            sprite = Default;
        }
    }
}
