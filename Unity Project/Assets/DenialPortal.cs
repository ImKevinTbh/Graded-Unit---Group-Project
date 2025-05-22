using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DenialPortal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("DenialScene");
            GameHandler.instance.Player_Unlock_RangedAttack = true; // Done by kevin because charlotte cant do her work properly
            PlayerController.Instance.Health = 3;
        }
        
    }
}
