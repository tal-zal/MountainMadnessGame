using UnityEngine;

public class LaserCollisionHandler : MonoBehaviour
{

    float speed = 2f;

    void Start(){

        // for now, start moving as soon as the game starts.
        Shoot();

    }


    void MoveRightFix(){
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Calculate the new position by adding 1 unit to the x-coordinate
        Vector3 newPosition = currentPosition + Vector3.right * 1f;

        // Update the object's position to the new position
        transform.position = newPosition;
    }

    void MoveDownFix()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Calculate the new position by subtracting 2 units from the z-coordinate
        Vector3 newPosition = currentPosition + Vector3.back * 1f;

        // Update the object's position to the new position
        transform.position = newPosition;
    }




    void Shoot(){

        // Shoot it to the right
        Vector3 initialVelocity = new Vector3(speed, 0f, 0f);

        // Apply the initial velocity to the Rigidbody component
        GetComponent<Rigidbody>().velocity = initialVelocity;
    }

    void ChangeDirectionDown(){
        Vector3 initialVelocity = new Vector3(0f, 0f, -speed);
        GetComponent<Rigidbody>().velocity = initialVelocity;
        gameObject.transform.Rotate(90f, 0f, 0f);

        // shift it to the right by 1f (half the size of a cube)
        MoveRightFix();

    }

    void ChangeDirectionUp(){
        Vector3 initialVelocity = new Vector3(0f, 0f, speed);
        GetComponent<Rigidbody>().velocity = initialVelocity;
        gameObject.transform.Rotate(90f, 0f, 0f);

        MoveRightFix();
    }

    void ChangeDirectionRight(){
        
        Vector3 initialVelocity = new Vector3(speed, 0f, 0f);
        GetComponent<Rigidbody>().velocity = initialVelocity;
        gameObject.transform.Rotate(90f, 0f, 0f);

        MoveDownFix();
    }

    void ChangeDirectionLeft(){
        Vector3 initialVelocity = new Vector3(-speed, 0f, 0f);
        GetComponent<Rigidbody>().velocity = initialVelocity;
        gameObject.transform.Rotate(0f, 0f, 90f);
    
        // TODO - this could be wrong.
        // MoveDownFix();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser entered trigger zone.");

        // Check if the trigger is the cube
        if (other.CompareTag("Cube"))
        {
            HandleCollision(other);
        }
        else if (other.CompareTag("Catcher"))
        {
            // If collided with the catcher, increase points and continue the game
            Debug.Log("Laser hit the catcher!");
            Destroy(gameObject);
            // Add your code to increase points and continue the game
        }
        else
        {
            // If collided with any other trigger, it's likely an obstacle. Game over!
            Debug.Log("Laser hit an obstacle! Game over!");
            // Add your code to end the game
        }


    }

    void HandleCollision(Collider cubeCollider)
    {
        // Get the velocity of the laser
        Vector3 laserVelocity = GetComponent<Rigidbody>().velocity;

        // Get the current directions of the pipes on the cube
        CubeRotate cubeRotate = cubeCollider.GetComponent<CubeRotate>();

        if (cubeRotate != null)
        {
            // Get the current pipe directions from the cube's CubeRotate component
            Direction pipeOneDirection = cubeRotate.pipeOne;
            Direction pipeTwoDirection = cubeRotate.pipeTwo;

            // Now you have the current pipe directions, you can use them as needed
            Debug.Log("Pipe One Direction: " + pipeOneDirection);
            Debug.Log("Pipe Two Direction: " + pipeTwoDirection);

            // Determine the direction based on the laser velocity and pipe directions
            if (Mathf.Abs(laserVelocity.x) > Mathf.Abs(laserVelocity.z))
            {
                // Moving primarily in the horizontal direction (left or right)
                if (laserVelocity.x > 0)
                {
                    Debug.Log("Laser was moving right.");

                    if (pipeOneDirection == Direction.LEFT)
                    {
                        if (pipeTwoDirection == Direction.UP)
                        {
                            ChangeDirectionUp();
                        }
                        else if (pipeTwoDirection == Direction.DOWN)
                        {
                            ChangeDirectionDown();
                        }
                    }
                    else if (pipeTwoDirection == Direction.LEFT)
                    {
                        if (pipeOneDirection == Direction.UP)
                        {
                            ChangeDirectionUp();
                        }
                        else if (pipeOneDirection == Direction.DOWN)
                        {
                            ChangeDirectionDown();
                        }
                    }
                }
                else
                {
                    Debug.Log("Laser was moving left.");
                    // THIS... should not happen.
                }
            }
            else
            {
                // Moving primarily in the vertical direction (up or down)
                if (laserVelocity.z > 0)
                {
                    Debug.Log("Laser was moving up.");

                    if (pipeOneDirection == Direction.DOWN)
                    {
                        if (pipeTwoDirection == Direction.LEFT)
                        {
                            ChangeDirectionLeft();
                        }
                        else if (pipeTwoDirection == Direction.RIGHT)
                        {
                            ChangeDirectionRight();
                        }
                    }
                    else if (pipeTwoDirection == Direction.DOWN)
                    {
                        if (pipeOneDirection == Direction.LEFT)
                        {
                            ChangeDirectionLeft();
                        }
                        else if (pipeOneDirection == Direction.RIGHT)
                        {
                            ChangeDirectionRight();
                        }
                    }

                }
                else
                {
                    Debug.Log("Laser was moving down.");

                    if (pipeOneDirection == Direction.UP)
                    {
                        if (pipeTwoDirection == Direction.LEFT)
                        {
                            ChangeDirectionLeft();
                        }
                        else if (pipeTwoDirection == Direction.RIGHT)
                        {
                            ChangeDirectionRight();
                        }
                    }
                    else if (pipeTwoDirection == Direction.UP)
                    {
                        if (pipeOneDirection == Direction.LEFT)
                        {
                            ChangeDirectionLeft();
                        }
                        else if (pipeOneDirection == Direction.RIGHT)
                        {
                            ChangeDirectionRight();
                        }
                    }

                }
            }
        }
    }
}

