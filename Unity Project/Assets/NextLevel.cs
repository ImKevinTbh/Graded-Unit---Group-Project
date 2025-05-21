using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// depricated(?)
public class NextLevel : MonoBehaviour
{
    public static NextLevel instance;

    public void Start()
    {
        instance = this;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

        SceneManager.LoadScene("AngerScene");
    }
}
