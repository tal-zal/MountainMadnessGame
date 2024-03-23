using UnityEngine;

public class TileBreakFollow : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen coordinates with the z-coordinate set to the distance from the camera
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);

        // Convert the screen coordinates to world coordinates
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update the position of the object to the world mouse position
        transform.position = worldMousePosition;
    }
}
