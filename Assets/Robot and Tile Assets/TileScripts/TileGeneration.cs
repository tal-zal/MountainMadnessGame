using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    public GameObject tilePrefab; // Reference to the tile prefab
    public int gridWidth = 10; // Number of tiles in the grid horizontally
    public int gridHeight = 10; // Number of tiles in the grid vertically
    public float spacing = 1f; // Spacing between each tile

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Generate grid of tiles
    void GenerateGrid()
    {
        // Loop through the grid rows
        for (int y = 0; y < gridHeight; y++)
        {
            // Loop through the grid columns
            for (int x = 0; x < gridWidth; x++)
            {
                // Calculate the position for the current tile
                Vector3 tilePosition = new Vector3(x * spacing, 0f, y * spacing);

                // Instantiate the tile prefab at the calculated position
                GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);

                newTile.transform.Rotate(270f, 0f, 0f);

                // Optionally, you can parent the tile to this object for better organization
                newTile.transform.parent = transform;

                Debug.Log("Current Position: " + tilePosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
