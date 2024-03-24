using UnityEngine;

public class TileBreakFollow : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float distance = 2f; // Desired distance from the player

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set!");
            return;
        }

        // Calculate the position offset based on the player's Y rotation
        Vector3 offset = Quaternion.Euler(0f, player.rotation.eulerAngles.y, 0f) * Vector3.forward * distance;

        // Calculate the target position based on the player's position and the offset
        Vector3 targetPosition = player.position + offset;

        // Set the target object's position
        transform.position = targetPosition;

        // Rotate the object to match the player's rotation
        transform.rotation = Quaternion.Euler(0f, player.rotation.eulerAngles.y, 0f);

        // Check for left mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            // Check if this is currently colliding with a tile. If yes, remove that tile.
            
        }
    }
}
