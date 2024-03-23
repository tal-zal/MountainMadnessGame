using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject plane;

    Rigidbody rb;
    bool isGrounded;

    void Start()
    {
        Console.WriteLine("Created player!!!");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Rotate to follow the mouse cursor
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float distance = 0.1f; // Adjust this distance based on your player's height
        Vector3 origin = transform.position + Vector3.up * 0.1f; // Offset slightly above the player's position

        if (Physics.Raycast(origin, Vector3.down, out hit, distance))
        {
            if (hit.collider.gameObject == plane)
            {
                return true;
            }
        }

        return false;
    }
}
