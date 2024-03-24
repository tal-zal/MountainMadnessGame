using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    void RotateCube()
    {
        gameObject.transform.Rotate(0f, 90f, 0f);
    }

    void Update()
    {
        // Check if right mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            // Check if the mouse is over the cube GameObject
            if (IsMouseOverObject())
            {
                RotateCube(); // Rotate the cube
            }
        }
    }

    bool IsMouseOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast a ray from the camera through the mouse position and check if it hits the cube GameObject
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }
}
