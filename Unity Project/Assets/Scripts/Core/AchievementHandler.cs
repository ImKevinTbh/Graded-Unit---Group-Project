using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;
using EventArgs;
using UnityEngine.SceneManagement;
using MEC;
//using UnityEngine.UIElements;
using UnityEngine.UI;

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
    [SerializeField] public Image uiImage;
    public int test;
    private float heightMax;
    private float heightMin;
    private bool hitTop = false;
    private bool moveDown = false;

    public string levelID;

    

    // subscribes to acheivement event sets default variables
    void Start()
    {
        Events.Level.OnAcheivement += Acheivement;
        heightMax = transform.localPosition.y;
        heightMin = heightMax - 160;
        DontDestroyOnLoad(gameObject);
        transform.localPosition = new Vector2(transform.localPosition.x, heightMin);
        levelID = MapController.Instance.LevelID;
        gameObject.SetActive(false);
    }

    //          EventHandler.Level._Acheivement();
    //          To ping event

    // checks each level and sets its sprite depending
    // also slowly moves up into frame from the bottom right, holds for 5 seconds, then slowly moves back down out of frame
    void Acheivement()
    {
        gameObject.SetActive(true);
        

        if (levelID == "Limbo")
        {
            uiImage.sprite = Limbo;
            Debug.Log("Achievement Triggered Limbo");
            return;
        }
        else if (levelID == "Grief")
        {
            uiImage.sprite = Grief;
            return;
        }
        else if (levelID == "Denial")
        {
            uiImage.sprite = Denial;
            return;
        }
        else if (levelID == "Anger")
        {
            Debug.Log("Achievement Anger, sprite: " + uiImage.sprite.name);

            uiImage.sprite = Anger;
            return;
        }
        else if (levelID == "Bargaining")
        {
            uiImage.sprite = Bargaining;
            Debug.Log("Achievement Bargaining, sprite: " + uiImage.sprite.name);
            return;
        }
        else if (levelID == "Depression")
        {
            uiImage.sprite = Depression;
            return;
        }
        else if (levelID == "Acceptance")
        {
            uiImage.sprite = Acceptance;
            return;
        }
        //else
        //{
        //    sprite = Default;

        //}
    }

    private void Update()
    {
        if (gameObject.transform.localPosition.y < heightMax && !hitTop)
        {
            gameObject.transform.localPosition += Vector3.up * 1.5f;
            Debug.Log("Achievement Moving UP");

        }
        else if (gameObject.transform.localPosition.y >= heightMax && !hitTop)
        {
            hitTop = true;
            Timing.CallDelayed(5.0f, () => moveDown = true);
            Debug.Log("Current Height: " + gameObject.transform.localPosition.y + " Max Height: " + heightMax);

        }
        else if (moveDown && gameObject.transform.localPosition.y > heightMin)
        {
            gameObject.transform.localPosition -= Vector3.up * 2f;
            Debug.Log("Achievement Moving down");

        }
        else if (gameObject.transform.localPosition.y <= heightMin)
        {
            moveDown = false;
            hitTop = false;
            Debug.Log("Achievement stopping at the bottom");
            gameObject.SetActive(false);
        }
    }
}
