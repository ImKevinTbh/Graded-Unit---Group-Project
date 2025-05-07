using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public TMP_Text ui;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ui.text = $"Speed {PlayerController.Instance.gameObject.GetComponent<Rigidbody2D>().velocity.ToString()} \nScore {ScoreHandler.Score.ToString()}";
    }
}
