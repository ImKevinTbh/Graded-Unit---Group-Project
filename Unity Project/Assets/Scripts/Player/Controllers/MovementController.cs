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


    //- variables that are ONLY used for tracking info should be prefixed by a `_` symbol so I can find tracking vs functional variables later -//


    public void Awake() // Run *AFTER* object is done instantiating and this component script is being loaded (DO NOT USE START UNLESS YOU REALLY NEED TO)
    {
        mask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        _JumpsUsed = MaxJumps; // Set Initial Jumps to maxJumps

        // Incase someone changes this, movement doesn't work right if these settings get changed in the editor so I'm hardcoding them
        rb.gravityScale = 3f;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float inputX = Mathf.Clamp((int)Input.GetAxis("Horizontal"), -1, 1);
        float inputY = Mathf.Clamp((int)Input.GetAxis("Vertical"), -1, 1);


        bool NoInput = false; if (inputX == 0 || (CheatMode && inputY == 0)) { NoInput = true; }

        Vector2 movement;

        if (!CheatMode) { movement = new Vector2(inputX * Speed, 0f); } else { movement = new Vector2(inputX * Speed, inputY * Speed); }

        movement *= Time.deltaTime * 100;

        if (!GroundCheck())
        {
            OnGround = false;
        }
        else
        {
            OnGround = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }

        Move(movement, CheatMode, NoInput);


    }

    public void Jump()
    {

        if (GroundCheck())
        {
            _JumpsUsed = 0;
        }

        if (_JumpsUsed < MaxJumps)
        {
            _JumpsUsed++;
            rb.velocity = new Vector2(rb.velocity.x, JumpPower * (rb.mass + rb.gravityScale / 10));
            AudioSource.PlayClipAtPoint(JumpSFX, CameraController.instance.transform.position);
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
        if (collision.gameObject.CompareTag("Boundary"))
        {
            gameObject.transform.position = Spawn;
            rb.velocity = Vector2.zero;
            OnGround = false;

        }
    }

    public bool GroundCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one / 2, 0, Vector2.down, 1f, mask);
        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}
