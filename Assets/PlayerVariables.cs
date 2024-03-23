using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    // the current level the player is on of this game. When they fall, this value is decremented.
    public static int currentPlayerPoints = 10;



    // Example global variables
    public static int playerScore = 0;

    public static bool isGamePaused = false;
}