using UnityEngine;

public enum Direction {
    UP, 
    RIGHT, 
    DOWN, 
    LEFT
}


public class CubeRotate : MonoBehaviour
{

    public Direction pipeOne = Direction.LEFT;
    public Direction pipeTwo = Direction.DOWN;
     
    // when you rotate right, the pipes also rotate
    void swapPipeDirections(){
        pipeOne = (Direction)(((int)pipeOne + 1) % 4);
        pipeTwo = (Direction)(((int)pipeTwo + 1) % 4);
    }    

    void RotateCube()
    {
        swapPipeDirections();
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
