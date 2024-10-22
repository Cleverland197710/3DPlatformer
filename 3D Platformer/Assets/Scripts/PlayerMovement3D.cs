using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{

    public Transform groundCheckPoint;     // A point to check if the player is grounded
    public float checkRadius = 10f;       // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;

    private Rigidbody rb;                // Refrence to the Rigidbody component
    private bool isGrounded;               // Is the player on the ground?
    private bool startFall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody2D component attached to the player


    }

    // Update is called once per frame
    void Update()
    {

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        
        if (isGrounded && Input.GetKeyDown("space"))
        {
            jump();
        }

        
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-3, 0, 0);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(3, 0, 0);
        }

    }

    private void jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 7, 0);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }
}
