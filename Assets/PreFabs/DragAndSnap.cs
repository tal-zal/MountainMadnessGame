using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 snapPosition;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
        // Snap to nearest grid position
        transform.position = snapPosition;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 targetPosition = mousePos + offset;
            transform.position = targetPosition;
        }
        // Calculate the nearest grid position
        snapPosition = GetNearestGridPosition(transform.position);
    }

    Vector3 GetMouseWorldPosition()
    {
        // Get mouse position in screen coordinates
        Vector3 mousePos = Input.mousePosition;

        // Set the z position to the distance from the camera to the game objects
        mousePos.z = Camera.main.transform.position.y;

        // Convert the screen coordinates to world coordinates
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Return only the x and z components of the world position
        return new Vector3(worldPos.x, 0f, worldPos.z);
    }


    // cap the out of bounds.
    Vector3 GetNearestGridPosition(Vector3 position)
    {
        float gridSize = 2.0f; // Change this to the size of your grid square
        
        float x = Mathf.Round(position.x / gridSize) * gridSize;
        if (x > 18f)
        {
            x = 18f;
        }
        if (x < 0f)
        {
            x = 0f;
        }
        
        float z = Mathf.Round(position.z / gridSize) * gridSize;
        if (z > 18f)
        {
            z = 18f;
        }
        if (z < 0f)
        {
            z = 0f;
        }
        
        // Check if there's an object at the target position
        

        return new Vector3(x, position.y, z);
    }
}
