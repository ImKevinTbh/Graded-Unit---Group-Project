using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour

{
    public static NextLevel3 instance;

    public void Start()
    {
        instance = this;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController.Instance.Health = PlayerController.Instance.MaxHealth;
        SceneManager.LoadScene("Bargaining");
    }
}

