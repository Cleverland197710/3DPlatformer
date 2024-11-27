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
    [SerializeField] int numberOfJumps = 2;
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

        if (Input.GetButtonDown("Jump") && maxNumberOfjumps >= numberOfJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            numberOfJumps++;

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
}
