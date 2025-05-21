using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static NextLevel instance;

    public void Start()
    {
        instance = this;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController.Instance.Health = PlayerController.Instance.MaxHealth;
        SceneManager.LoadScene("AngerScene");
    }
}
