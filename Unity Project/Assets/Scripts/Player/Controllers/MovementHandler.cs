//- THIS CODE WAS WRITTEN BY KEVIN WATSON -//
using System;
using MEC;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class MovementHandler : MonoBehaviour 
{

    //- Fixed list of available states -//


    //- Settings -// 
    public float Speed = 35f;
    public float OriginMaxSpd;
    public float MaxSpeed = 7.5f;

    public float JumpPower = 10;
    public int MaxJumps = 2;
    public int _JumpsUsed = 0;

    public bool CheatMode = false;

    public Vector2 Spawn;
    private LayerMask mask;
    private Rigidbody2D rb;

    public AudioClip JumpSFX;

    public bool CanToggleCheatMode = true;
    public bool OnGround = false;
    //referencing animator to allow for correct animation transitions - Lilith
    public Animator anim;
    public static MovementHandler instance;
    public float inputX;
    public float inputY;

    public float direction;

    // Parameter Setting, Public params are for external use, private params only get used within this script
    
    
    //- variables that are ONLY used for tracking info should be prefixed by a `_` symbol so I can find tracking vs functional variables later -//


    public void Awake() // Run *AFTER* object is done instantiating and this component script is being loaded (DO NOT USE START UNLESS YOU REALLY NEED TO)
    {
        instance = this;
        OriginMaxSpd = MaxSpeed;
        mask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        _JumpsUsed = MaxJumps; // Set Initial Jumps to maxJumps

        // Incase someone changes this, movement doesn't work right if these settings get changed in the editor so I'm hardcoding them
        rb.gravityScale = 3f; // Unity's gravity is awful
        rb.freezeRotation = true; // Stop the player falling over *optional*
    }

    void Update()
    {
        CheatMode = Settings.instance.CheatMode;
        inputX = Mathf.Clamp((int)Input.GetAxis("Horizontal"), -1, 1); // Get input on the X axis, Round it to the nearest 1 and clamp the value so that it can never be anything other than 0,-1,1
        inputY = Mathf.Clamp((int)Input.GetAxis("Vertical"), -1, 1); // Get input on the X axis, Round it to the nearest 1 and clamp the value so that it can never be anything other than 0,-1,1
        
        if (inputX == 1)
        {
            direction = inputX;
        }
        if (inputX == -1)
        {
            direction = inputX;
        }

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

        if (Input.GetKeyDown(KeyCode.Q) && GameHandler.instance.Player_Unlock_Dash)
        {
            movement = movement * 2;
            MaxSpeed = OriginMaxSpd * 10;
            Timing.CallDelayed(1f, () => MaxSpeed = OriginMaxSpd);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {

            if (CanToggleCheatMode)
            {
                CanToggleCheatMode = false;
                Settings.instance.CheatMode = !CheatMode;
                if (!CheatMode)
                {
                    PlayerController.Instance.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; // Make character yellow
                }
                else
                {
                    PlayerController.Instance.gameObject.GetComponent<SpriteRenderer>().color = Color.white; // Make character not yellow
                }
                Debug.LogWarning($"Cheatmode is: {!CheatMode}");
                Timing.CallDelayed(1f, () => { CanToggleCheatMode = true; });
            }

            
        } // Toggle Cheatmode by inverting the variable
        
        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); } // Run my jump method if spacebar is pressed
        

        Move(movement, NoInput); // Run movement method every update with passed parameters

        if (inputX != (int)0)//checks for correct key inputs in order to play running animation
        {
            anim.SetBool("IsRunning", true);
            //Debug.Log("Movement:" + gameObject.GetComponent<Rigidbody2D>().velocity.x);
        }
       
        else
        {
            anim.SetBool("IsRunning", false);
            //Debug.Log("we stop");
        }

    }

    public void Jump()
    {
        if (!GameHandler.instance.Player_Unlock_DoubleJump)
        {
            MaxJumps = 1;
        }
        else
        {
            MaxJumps = 2;
        }
        
        
        if (GroundCheck())
        {
            _JumpsUsed = 0;
        }
        Debug.Log("Can't Jump)");

        if (_JumpsUsed < MaxJumps)
        {
            _JumpsUsed++; // Increment the value of the _JumpsUsed variable by 1
            rb.velocity = new Vector2(rb.velocity.x, JumpPower * (rb.mass + rb.gravityScale / 10)); // Construct a new velocity value to move the player upwards
            AudioSource.PlayClipAtPoint(JumpSFX, CameraController.instance.transform.position); // Play a stupid sound effect when jumping on the player's position in worldspace, this is a bit clunky
        }

    }

    public void Move(Vector2 movement, bool NoInput) 
    {
        
        
        if (NoInput)
        {
            if (GroundCheck()) { rb.velocity = new Vector3(rb.velocity.x * 0.97f, rb.velocity.y, 0f); } // Slowly Reduce Velocity on the X axis while keeping Y axis the same} // Drag while on ground
            else { rb.velocity = new Vector3(rb.velocity.x * 0.9975f, rb.velocity.y, 0f); } // Slowly Reduce Velocity on the X axis while keeping Y axis the same (More precise, even slower) }// Drag while NOT on ground
        }

        if (movement.x < 0) // Going left
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); // Set scale on the X axis to negative to essentially flip the object 
        }
        else if (movement.x > 0) // Going right
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); // Set scale on the X axis to positive to unflip the object
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
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one / 2, 0, Vector2.down, 2f, mask); // cast downwards by 2 meters
        Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.red);
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
