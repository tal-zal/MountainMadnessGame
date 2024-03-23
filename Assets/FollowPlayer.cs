using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset;   // Offset between the camera and the player

    void Update()
    {
        // Ensure the player reference is set
        if (player == null)
        {
            Debug.LogWarning("Player reference not set in FollowPlayer script.");
            return;
        }

        // Update the camera's position to match the player's position with the offset
        transform.position = player.position + offset;
    }
}
