using UnityEngine;

public class MovableObjectsChecks : MonoBehaviour
{
    public static int ARRAY_SIZE = 10;
    public int[,] gridArray = new int[ARRAY_SIZE, ARRAY_SIZE];

    void Start()
    {
        ResetArray();
    }

    public bool CheckCollision(int x, int y)
    {
        if (IsOutOfBounds(x, y))
        {
            return true; // Indicate collision if position is out of bounds
        }

        return gridArray[x, y] == 1; // Indicate collision if grid position is already occupied
    }

    public void SetCollision(int x, int y)
    {
        if (!IsOutOfBounds(x, y))
            gridArray[x, y] = 1;
    }

    private void ResetArray()
    {
        for (int i = 0; i < ARRAY_SIZE; i++)
        {
            for (int j = 0; j < ARRAY_SIZE; j++)
            {
                gridArray[i, j] = 0;
            }
        }
    }

    private bool IsOutOfBounds(int x, int y)
    {
        return x < 0 || x >= ARRAY_SIZE || y < 0 || y >= ARRAY_SIZE;
    }
}
