using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respPoint;


    // Start is called before the first frame update
    // This tells the respawn agent where the player should be placed when respawning
    void Start()
    {
        // These are the player's starting co-ordinates
        respPoint = new Vector3(0, 2, 0);

    }

    // Update is called once per frame
    void Update()
    {
        // Origin is where the raycast will start and direction is where the raycast is pointing
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.right;

        // This is what creates the raycast and sets its max distance.
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 1000f);

        // If something hits the raycast, it will spawn them at the Respawn Point 
        if (hit.collider != null)
        {
            hit.collider.transform.position = respPoint;
        }
    }
}
