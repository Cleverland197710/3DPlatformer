using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;

    public float clampCam1;
    public float clampCam2;

    [SerializeField] float mouseSensitivity = 100f;
    float xRotation = 0f;
    [SerializeField] Transform playerCamera; // Assign your camera in the Inspector

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int numberOfJumps = 1;
    [SerializeField] int maxNumberOfjumps = 2;

    Animator myAnim; //Slide 19



    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor in place
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampCam1, clampCam2); // Clamp vertiacl rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate camera up/down
        transform.Rotate(Vector3.up * mouseX); // Rotate player left/right


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move in the direction the player is facing
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        
        myAnim.SetFloat("speed", moveDirection.magnitude);

        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.W) && IsGrounded())
        {
            myAnim.SetTrigger("Forward");
        }

        /*if (Input.GetKey(KeyCode.S))
        {
            myAnim.SetTrigger("Backward");
        }*/

        if (IsGrounded())
        {
            myAnim.SetTrigger("still");
        }

       //myAnim.SetBool("isOnGround", isOnGround);



        /*if (!IsGrounded())
        {
            myAnim.SetBool("Air");
        }*/

        /*if (Input.GetKeyDown("q"))
        {
            Kill();

        }

        if (Input.GetButtonDown("Jump") && maxNumberOfjumps >= numberOfJumps)
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            Debug.Log(numberOfJumps);
            //numberOfJumps++;
            Debug.Log(numberOfJumps);
            jump();
        }*/

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }




        if (IsGrounded())
            {
                numberOfJumps = 0;
            }

       if (Input.GetKeyDown(KeyCode.Escape))
       {
            UnlocK();
       }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            LocK();
        }
        Debug.Log(numberOfJumps);
    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        myAnim.SetTrigger("Air");
    }

    private void UnlocK()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LocK()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }

    private void numJumpReset()
    {
        numberOfJumps = 0;
    }

        
}


    /*bool Kill()
    {
        if (collision.gameObject.CompareTag("Dangerous"))
        {
            Destroy(parent.gameObject)
        }
    }*/
