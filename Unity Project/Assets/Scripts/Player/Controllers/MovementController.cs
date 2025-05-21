//- THIS CODE WAS WRITTEN BY KEVIN WATSON -//
using System;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MovementHandler : MonoBehaviour 
{

    //- Fixed list of available states -//


    //- Settings -// 
    public float Speed = 35f;
    public float MaxSpeed = 7.5f;

    public float JumpPower = 10;
    public int MaxJumps = 2;
    public int _JumpsUsed = 0;

    public bool CheatMode = false;

    public Vector2 Spawn;
    private LayerMask mask;
    private Rigidbody2D rb;

    public AudioClip JumpSFX;

    public bool OnGround = false;

    // Parameter Setting, Public params are for external use, private params only get used within this script
    
    
    //- variables that are ONLY used for tracking info should be prefixed by a `_` symbol so I can find tracking vs functional variables later -//


    public void Awake() // Run *AFTER* object is done instantiating and this component script is being loaded (DO NOT USE START UNLESS YOU REALLY NEED TO)
    {
        mask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        _JumpsUsed = MaxJumps; // Set Initial Jumps to maxJumps

        // Incase someone changes this, movement doesn't work right if these settings get changed in the editor so I'm hardcoding them
        rb.gravityScale = 3f; // Unity's gravity is awful
        rb.freezeRotation = true; // Stop the player falling over *optional*
    }

    void Update()
    {
        float inputX = Mathf.Clamp((int)Input.GetAxis("Horizontal"), -1, 1); // Get input on the X axis, Round it to the nearest 1 and clamp the value so that it can never be anything other than 0,-1,1
        float inputY = Mathf.Clamp((int)Input.GetAxis("Vertical"), -1, 1); // Get input on the X axis, Round it to the nearest 1 and clamp the value so that it can never be anything other than 0,-1,1
        
        // Analogue Inputs are absolutely terrible 

        bool NoInput = false; if (inputX == 0 || (CheatMode && inputY == 0)) { NoInput = true; } // Check if the user is pressing any movement inputs (I use this for manual drag because unity's inbuilt physics are shit.

        Vector2 movement;

        if (!CheatMode) { movement = new Vector2(inputX * Speed, 0f); } else { movement = new Vector2(inputX * Speed, inputY * Speed); } // Cheatmode setting check, WIP

        movement *= Time.deltaTime * 100; // Multiply movement vector by the time between frames so that the value is consistent no matter the client's framerate

        if (!GroundCheck()) // Run my method to check if the player is on the ground
        {
            OnGround = false;
        }
        else
        {
            OnGround = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); } // Run my jump method if spacebar is pressed

        Move(movement, CheatMode, NoInput); // Run movement method every update with passed parameters


    }

    public void Jump()
    {

        if (GroundCheck())
        {
            _JumpsUsed = 0;
        }

        if (_JumpsUsed < MaxJumps)
        {
            _JumpsUsed++; // Increment the value of the _JumpsUsed variable by 1
            rb.velocity = new Vector2(rb.velocity.x, JumpPower * (rb.mass + rb.gravityScale / 10)); // Construct a new velocity value to move the player upwards
            AudioSource.PlayClipAtPoint(JumpSFX, CameraController.instance.transform.position); // Play a stupid sound effect when jumping on the player's position in worldspace, this is a bit clunky
        }

    }

    public void Move(Vector2 movement, bool CheatMode, bool NoInput) 
    {
        if (NoInput)
        {
            if (GroundCheck()) { rb.velocity = new Vector3(rb.velocity.x * 0.97f, rb.velocity.y, 0f); } // Slowly Reduce Velocity on the X axis while keeping Y axis the same} // Drag while on ground
            else { rb.velocity = new Vector3(rb.velocity.x * 0.9975f, rb.velocity.y, 0f); } // Slowly Reduce Velocity on the X axis while keeping Y axis the same (More precise, even slower) }// Drag while NOT on ground
        }

        if (movement.x < 0) // Going left
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // Set scale on the X axis to negative 1 to essentially flip the object 
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue; // Change colour of renderer to blue
        }
        else if (movement.x > 0) // Going right
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); // Set scale on the X axis to 1 to unflip the object
            gameObject.GetComponent<SpriteRenderer>().color = Color.red; // Change colour of renderer to red
        }


        Vector2 vel = rb.velocity; // We cant modify velocity directly on a single axis so copy it to a variable
        vel.x = Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed); //  Stop going too fast by using the clamp method and giving it min/max parameters

        rb.velocity = vel; // Now set the velocity back to whatever we had in the variable
        rb.AddForce(movement, ForceMode2D.Force);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary")) // If the collision the player is exiting has the tag "Boundary"
        {
            EventHandler.Player._Hurt(new EventArgs.HurtEventArgs(PlayerController.Instance.gameObject, this.gameObject, 1)); // Hurt the player
            gameObject.transform.position = Spawn; // Move the player back to spawn
            rb.velocity = Vector2.zero; // Reset the player's velocity so we can't do some kind of weird speed farming thing
            OnGround = false; // stops the player jumping on spawn causing weird behaviour

        }
    }

    public bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one / 2, 0, Vector2.down, 1f, mask); // cast downwards by 1 meter 
        if (hit.collider == null)
        {
            return false; // If the ray hits nothing, the player is not on the ground
        }
        else
        {
            return true; // If the ray hits *something* on the specified layer then they are on the ground
        }
    }


}
