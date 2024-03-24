using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your cube prefab in the Unity Editor

    void Start()
    {
        // Instantiate two cubes at random positions on the grid
        InstantiateCube();
        InstantiateCube();
    }

    void InstantiateCube()
    {
        // Generate random coordinates for the cube within the grid
        float randomX = Random.Range(0, 9) * 2f; // Adjust 9 according to your grid size
        float randomZ = Random.Range(0, 9) * 2f; // Adjust 9 according to your grid size
        Vector3 spawnPosition = new Vector3(randomX, 1f, randomZ);

        // Instantiate the cube at the random position
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
    }
}
