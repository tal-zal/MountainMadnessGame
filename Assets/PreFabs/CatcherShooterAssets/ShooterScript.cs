using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour
{
    // TODO - possibly change with high score?
    public int numObstacles = 2;


    public GameObject cylinderPrefab;
    public GameObject cubePrefab; // Reference to the CubeObstacle prefab
    public GameObject catcher; // Reference to the catcher object
    public float minYRange = -5f;
    public float maxYRange = 5f;
    public float floatingSpeed = 1f;
    public float minZPosition = 0f;
    public float maxZPosition = 18f;

    private GameObject lastShotObject; // Reference to the last shot object
    private List<GameObject> cubeObstacles = new List<GameObject>(); // List to store CubeObstacle objects
    private Coroutine moveCoroutine;

    void Start()
    {
        // Start the movement routine for both shooter and catcher
        moveCoroutine = StartCoroutine(MoveShooterAndCatcher());
    }

    IEnumerator MoveShooterAndCatcher()
    {
        while (true)
        {
            // Wait until the last shot object is destroyed
            while (lastShotObject != null)
            {
                yield return null;
            }

            // Clean up old CubeObstacle objects
            foreach (GameObject cube in cubeObstacles)
            {
                Destroy(cube);
            }
            cubeObstacles.Clear();

            // Calculate random target z positions for shooter and catcher
            float randomZShooter = Random.Range(minZPosition, maxZPosition);
            float randomZCatcher = Random.Range(minZPosition, maxZPosition);
            randomZShooter = Mathf.Round(randomZShooter / 2) * 2; // Round to the nearest multiple of 2
            randomZCatcher = Mathf.Round(randomZCatcher / 2) * 2;

            float initialZShooter = transform.position.z;
            float initialZCatcher = catcher.transform.position.z;

            float t = 0f;
            while (t < 1f)
            {
                // Move both shooter and catcher towards their target z positions
                t += Time.deltaTime / floatingSpeed;
                float currentZShooter = Mathf.Lerp(initialZShooter, randomZShooter, t);
                float currentZCatcher = Mathf.Lerp(initialZCatcher, randomZCatcher, t);
                transform.position = new Vector3(transform.position.x, transform.position.y, currentZShooter);
                catcher.transform.position = new Vector3(catcher.transform.position.x, catcher.transform.position.y, currentZCatcher);
                yield return null;
            }

            // Shoot
            Shoot();
        }
    }

void Shoot()
{
    // Clean up old CubeObstacle and Cube objects
    foreach (GameObject cube in cubeObstacles)
    {
        Destroy(cube);
    }
    cubeObstacles.Clear();

    // Define the boundaries of the grid tiles
    float minX = 2f;
    float maxX = 16f;
    float minZ = 2f;
    float maxZ = 16f;

    // List to store occupied positions
    List<Vector3> occupiedPositions = new List<Vector3>();

    // Add all cubes to the list.

    foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube"))
    {
        occupiedPositions.Add(cube.transform.position);
    }

    Debug.Log("Shoot is called.");

    // Spawn new CubeObstacle prefabs
    for (int i = 0; i < numObstacles; i++)
    {
        Vector3 randomPosition = Vector3.zero;
        bool positionFound = false;

        // Try to find a valid position for the new obstacle
        while (!positionFound)
        {
            // Generate random positions within the grid boundaries
            float randomX = Mathf.Round(Random.Range(minX, maxX) / 2f) * 2f; // Snap to nearest multiple of 2
            float randomZ = Mathf.Round(Random.Range(minZ, maxZ) / 2f) * 2f; // Snap to nearest multiple of 2

            randomPosition = new Vector3(randomX, 1f, randomZ);

            // Check if the random position is not already occupied
            if (!occupiedPositions.Contains(randomPosition))
            {
                positionFound = true;
                occupiedPositions.Add(randomPosition); // Add the new position to the occupied list
            }
        }

        // Instantiate the CubeObstacle prefab at the valid position
        GameObject cube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        cube.transform.Rotate(0f, 0f, 180f);

        cubeObstacles.Add(cube);
    }

    // Instantiate the cylinder at the shooter's position
    lastShotObject = Instantiate(cylinderPrefab, transform.position, Quaternion.identity);
}


    Vector3 GetRandomInnerPosition()
    {
        // Generate random coordinates within the inner area of the grid
        float randomX = Random.Range(minYRange, maxYRange);
        float randomZ = Random.Range(minZPosition + 2f, maxZPosition - 2f); // Ensure the cube is not on the outer edges
        // Convert random coordinates to world space
        Vector3 randomWorldPosition = new Vector3(randomX, 0f, randomZ);

        return randomWorldPosition;
    }

    void Update()
    {
        // Check if the last shot object is destroyed
        if (lastShotObject != null && !lastShotObject.activeSelf)
        {
            // If destroyed, reset the last shot object reference
            lastShotObject = null;
        }
    }
}
