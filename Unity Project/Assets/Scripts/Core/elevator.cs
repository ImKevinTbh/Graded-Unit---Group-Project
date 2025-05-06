using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float platformFloatHeight; // increases height exponentially, 1 = going from the floor of the boss room to the players head touching the ceiling
    private float i = 0.0f;
    private float velocityMultiplier;
    Rigidbody2D rb;
    


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        platformFloatHeight += 0.45f;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformFloatHeight != 0)
        {
            // velocityMultiplier increases or decreases the platform velocity along a cosine wave for smooth stops at the top and bottom
            velocityMultiplier = Mathf.Cos(i / platformFloatHeight);
            i += Time.deltaTime;

            rb.velocity += new Vector2(0, 1 * Time.deltaTime) * velocityMultiplier * 5;

            Debug.Log("Y = " + velocityMultiplier + "| I = " + i + "| Velocity = " + rb.velocity.magnitude);
        }
    }
}
