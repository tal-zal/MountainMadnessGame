using UnityEngine;

public class TileBreakFollow : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float distance = 10f; // Desired distance from the player

    void Update()
    {
        // Calculate the position offset based on the player's Y rotation
        Vector3 offset = Quaternion.Euler(0f, player.rotation.eulerAngles.y, 0f) * Vector3.forward * distance;

        // Calculate the target position based on the player's position and the offset
        Vector3 targetPosition = player.position + offset;

        // Set the target object's position
        gameObject.transform.position = targetPosition;

        // Rotate the object to match the player's rotation
    }
}
