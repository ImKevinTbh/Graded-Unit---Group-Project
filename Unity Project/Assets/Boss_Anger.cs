using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Anger : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackCooldown = 3f;
    private Transform player;
    private float nextAttackTime = 0f;
    public static float Health { get; set; }
    public static float Speed { get; set; }
    public static int Damage { get; set; }
    public float DistanceFromPlayer;
    public AudioClip DyingSFX;
    public Vector2 Direction = Vector2.left;
    public LayerMask Mask;
    public Rigidbody2D rb;
    public bool SpottedPlayer = false;
    public GameObject Player;
    public float VisionDistance = 5.0f;
    public float GroundDistance = 2.0f;
    public float WidthScale = 1.0f;
    public bool Movement = true;
    public float JumpPower = 10;
    public int MaxJumps = 2;
    public int _JumpsUsed = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime){ Jump(); }
        // Move towards the player
        // Raycasts towards the players current possition from the enemies current possition at a distance defined in VisionDistance
        RaycastHit2D PlayerCast = Physics2D.Raycast(gameObject.transform.position, Player.transform.position - gameObject.transform.position, VisionDistance, Mask);
        // if the ray collides with the player, changes the enemies direction towards the player
        if (PlayerCast && PlayerCast.collider.gameObject == Player)
        {
            SpottedPlayer = true;
            Direction.x = Player.transform.position.x - gameObject.transform.position.x;
            Direction = Direction.normalized;
            SpotPlayer();
            Debug.Log("Spotted Player");
        }
        else
        {
            SpottedPlayer = false;
            Debug.Log("Not Spotted Player "+PlayerCast.collider.gameObject.name);
        }

        // Raycasts a short distance in front of the enemy and diagonally down in front checking for walls and floors
        RaycastHit2D HorrizontalCast = (Physics2D.Raycast(gameObject.transform.position, Direction, 1.0f * WidthScale, Mask));
        //RaycastHit2D DiagonalCast = (Physics2D.Raycast(gameObject.transform.position, Direction + (Vector2.down * 1), GroundDistance, Mask));

        Debug.DrawRay(gameObject.transform.position, Direction * WidthScale, Color.red);
        //Debug.DrawRay(gameObject.transform.position, (Direction + (Vector2.down * 2) * GroundDistance), Color.red);
        Debug.Log("Raycast Done");

        // if either collide with a wall or floor, turns the enemy around
        if ((HorrizontalCast) && Movement)
        {
            Direction *= -1;
            Vector2 scale = gameObject.transform.localScale;
            //scale.x *= -1;
            gameObject.transform.localScale = scale;
            Debug.Log("No Floor, Big Wall");
        }


        Vector2 vel = rb.velocity; // We cant modify velocity directly on a single axis so copy it to a variable
        vel.x = Mathf.Clamp(rb.velocity.x, -Speed, Speed); //  Stop going too fast by using the clamp method and giving it min/max parameters
        Debug.Log("Speed Checked");

        rb.velocity = vel; // Now set the velocity back to whatever we had in the variable
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
        Debug.Log("Speed Set");

        // Attack if cooldown is over
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    public void SpotPlayer()
    {

    }

    void Attack()
    {
        // Implement boss attack logic here
        Debug.Log("Boss attacks!");
    }

    public void Jump()
    {

        if(Time.time >= nextAttackTime)
        {
            _JumpsUsed = 0;
        }
        Debug.Log("Can't Jump)");

        if (_JumpsUsed < MaxJumps)
        {
            _JumpsUsed++; // Increment the value of the _JumpsUsed variable by 1
            rb.velocity = new Vector2(rb.velocity.x, JumpPower * (rb.mass + rb.gravityScale / 10)); // Construct a new velocity value to move the player upwards
            //AudioSource.PlayClipAtPoint(JumpSFX, CameraController.instance.transform.position); // Play a stupid sound effect when jumping on the player's position in worldspace, this is a bit clunky
        }

    }

    //public void AttackPlayer()
    // {
    //    Vector3 direction = gameObject.transform.position - PlayerController.Instance.transform.position;
    //   Instantiate(AttackProjectile, Boss_Anger.instance.gameObject.transform.position, Quaternion.identity);
    //   Debug.Log("Spectral Sword")

    // }
}
