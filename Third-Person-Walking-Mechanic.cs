using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third-Person-Walking-Mechanic : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody rb;
    float horizontal_axis;
    float vertical_axis;
    public float speed = 20;
    public float sprintSpeed = 3f;

    [Header("Player Script Cameras")]
    public Transform playerCamera;

    [Header("Player Animator and Gravity")]
    public float gravity = -19.62f;

    [Header("Velocity and Jumping")]
    public float turnCalmTime = 0.5f;
    public float turnCalmTime2 = 0.3f;
    float turnCalmVelocity;
    public float jumpRange = 1f;
    public Transform surfaceCheck;
    public bool onSurface;
    public float surfaceDistance = 0f;
    public LayerMask surfaceMask;
    private float angle;
    [SerializeField] bool isJumping = false;

    public bool backPressed;
    public bool rightPressed;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Checking if the player is on a surface
        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistance, surfaceMask) ? true : false;

        // Checking if the 'S' key or the right mouse button is pressed
        backPressed = Input.GetKey(KeyCode.S) ? true : false;
        rightPressed = Input.GetKey(KeyCode.Mouse1) ? true : false;

        // Executing player movement code when on a surface
        if (onSurface)
        {
            PlayerMove();
            Jump();
        }
    }

    // Handles player movement based on input
    void PlayerMove()
    {
        horizontal_axis = Input.GetAxisRaw("Horizontal");
        vertical_axis = Input.GetAxisRaw("Vertical");

        // Determining the movement direction based on input
        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        // Handling movement when not pressing the 'S' key or right mouse button
        if (direction.magnitude >= 0.1f && !backPressed && !rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * speed * Time.deltaTime;
        }
        // Handling movement when pressing the right mouse button without the 'S' key
        else if (direction.magnitude >= 0.1f && !backPressed && rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * speed * Time.deltaTime;
        }
        // Handling movement when pressing the 'S' key without the right mouse button
        else if (direction.magnitude >= 0.1f && backPressed && !rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * speed * Time.deltaTime;
        }

        // Handling sprint movement in different directions
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && onSurface && !rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * sprintSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && onSurface && !rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * sprintSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) && onSurface && !rightPressed)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            rb.velocity = moveDirection.normalized * sprintSpeed * Time.deltaTime;
        }
    }

    // Handles the player's jumping action
    void Jump()
    {
        // Performs a jump when the spacebar is pressed and the player is on a surface and not already jumping
        if (Input.GetKeyDown(KeyCode.Space) && onSurface && !isJumping)
        {
            rb.AddForce(transform.up * 100);
        }
    }
}
