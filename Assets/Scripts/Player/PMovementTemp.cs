using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovementTemp : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;          // Normal movement speed
    public float sprintMultiplier = 2f;  // Speed multiplier when sprinting

    [Header("Look Settings")]
    public float mouseSensitivity = 2f;  // Mouse look sensitivity

    private float verticalLookRotation = 0f; // Tracks vertical camera rotation

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Gather");
        }
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow
        float upward = 0f;

        // Move up with Space, down with C
        if (Input.GetKey(KeyCode.E))
        {
            upward = 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            upward = -1f;
        }

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontal +
                                transform.forward * vertical +
                                transform.up * upward;

        // Handle sprinting
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        // Apply movement
        transform.position += moveDirection * currentSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal rotation (player body)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (camera or head)
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}


