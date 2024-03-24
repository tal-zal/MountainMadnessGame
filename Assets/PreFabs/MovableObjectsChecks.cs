using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsChecks : MonoBehaviour
{

    public static int ARRAY_SIZE = 10;

    public int[,] gridArray = new int[ARRAY_SIZE, ARRAY_SIZE];

    // Start is called before the first frame update
    void Start()
    {
        InitializeArray();
        
    }

    public bool CheckCollision(int x, int y){
        return CheckArrayIndexUsed(x, y);
    }

    public void SetCollision(int x, int y){
        SetArrayIndexUsed(x, y);
    }


    private bool CheckArrayIndexUsed(int x, int y){
        // TODO - CHANGE
        if (x > ARRAY_SIZE || x < 0){
            return true;
        }

        if (y > ARRAY_SIZE || y < 0){
            return true;
        }
        
        if (gridArray[x, y] == 1){
            return true;
        }
        return false;
    }

    private void SetArrayIndexUsed(int x, int y){
        if (x > ARRAY_SIZE || x < 0){
            return;
        }

        if (y > ARRAY_SIZE || y < 0){
            return;
        }
        gridArray[x, y] = 1;

    }

    private void ResetArray()
    {
        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                // Assign 0 to each element in the array
                gridArray[i, j] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
