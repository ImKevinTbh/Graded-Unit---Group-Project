using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Events;
using Unity.VisualScripting;
using MEC;
using EventArgs;

public class DialogueBox : MonoBehaviour
{

    public string[] initialDialogue;
    [SerializeField] public string[] secondaryDialogue;
    public string dialogue;
    public int index = 0;
    public int length = 0;
    public TextMeshProUGUI textMeshPro;
    private int changeCount = 0;
    private bool speaking = true;
    private bool firstSpeach = true;
    public float textSpeed;


    // Start is called before the first frame update
    void Awake()
    {
        Events.Level.BossArenaEnter += BossEnter;
        Events.Level.LayoutComplete += LayoutChange;
        Events.Level.BossLayoutChange += Change;

        textSpeed = 0.5f;

        // Get the TextMeshPro component in the children
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        if (textMeshPro != null)
        {
            // Set the text
            try { textMeshPro.text = initialDialogue[index].ToString(); } catch { dialogue = "Error"; }
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found in children!");
        }
        gameObject.SetActive(false);
    }

    void BossEnter()
    {
        gameObject.SetActive(true);
    }

    void LayoutChange()
    {
        firstSpeach = false;
    }

    void Change(BossLayoutChangeEventArgs e)
    {
        gameObject.SetActive(false);
    }


    public void Update()
    {
        if ((textMeshPro != null) && (changeCount == 0) && (firstSpeach = true))
        {
           
            try
            {
                if (speaking)
                {
                    speaking = false;
                    length = initialDialogue.Length;
                    Timing.CallDelayed(textSpeed, () =>
                    { 
                        textMeshPro.text = initialDialogue[index].ToString();   
                        speaking = true;
                        index++;

                        if (index == length)
                        {
                            index = 0;
                            changeCount++;
                            EventHandler.Level._LayoutCompete();

                        }
                        
                    });

                }
                
            }
            catch { }
        }

        if ((textMeshPro != null) && (changeCount > 0) && (changeCount < 3) && (firstSpeach = false))
        {

            try
            {
                if (speaking)
                {
                    speaking = false;
                    length = secondaryDialogue.Length;
                    Timing.CallDelayed(textSpeed, () =>
                    {
                        speaking = true;
                        index++;
                        if (index == length)
                        {
                            index = 0;
                            changeCount++;
                            EventHandler.Level._LayoutCompete();
                        }
                    
                    });
                
                }

            }
            catch { }
        }
    
    }

}
