using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// made by Lilith
public class HealthController : MonoBehaviour
{
    //initializes health variable
    public int health;

    //makes the private array to store the heart images a public variable in the editor
    [SerializeField] private Image[] hearts;

    void Update()
    {
        //sets the health variable to the Health value defined in the player controller, this allows for accurate tracking of health to display on the UI
        health = PlayerController.Instance.Health;
       for (int i = 0; i < hearts.Length; i++) // creates an integer variable (i) that is set to the initial value of the health variable, to a minimum of 0
        {
            if (i < health)
            {
                hearts[i].color = Color.red; //sets heart colour to red when health is greater than the i variable
            }
            else
            {
                hearts[i].color = Color.black; //sets heart colour to black when health becomes less than the i variable, to a minimum of 0
            }
        }
    }
}
