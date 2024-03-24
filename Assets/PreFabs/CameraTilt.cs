using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    public GameObject catcher; // Reference to the Catcher GameObject
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private bool isAlternatePosition = false;
    private bool isQKeyPressed = false;
    public float transitionDuration = 0.5f; // Reduced transition duration

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        // Initially set the target position and rotation to the original values
        targetPosition = originalPosition;
        targetRotation = originalRotation;

        catcher.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "q" key is pressed
        if (Input.GetKeyDown(KeyCode.Q) && !isQKeyPressed)
        {
            // Toggle between original position/rotation and alternate position/rotation
            if (isAlternatePosition)
            {
                targetPosition = originalPosition;
                targetRotation = originalRotation;
                Cursor.lockState = CursorLockMode.None; // Show cursor
                Cursor.visible = true;
                catcher.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                targetPosition = new Vector3(9f, 19f, -15f);
                targetRotation = Quaternion.Euler(40.4f, originalRotation.eulerAngles.y, originalRotation.eulerAngles.z);
                Cursor.lockState = CursorLockMode.Locked; // Hide cursor
                Cursor.visible = false;
                catcher.GetComponent<MeshRenderer>().enabled = true;
            }

            // Update the toggle flags
            isAlternatePosition = !isAlternatePosition;
            isQKeyPressed = true;
        }

        // Check if the "q" key is released
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isQKeyPressed = false;
        }

        // Move towards the target position and rotation using interpolation
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / transitionDuration);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / transitionDuration);
    }
}
