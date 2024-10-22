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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody2D component attached to the player


    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 7f, rb.velocity.);
        }


        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, 3);
        }

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -3);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-3, 0, 0);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(3, 0, 0);
        }

    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }

    //https://youtu.be/HmouLR4X47I?si=fqVb4T9DeL5upgrX&t=1025
}
