using UnityEngine;
using System.Collections; 
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component

    private int score = 0;

    void Start()
    {
        // Initialize the score display
        UpdateScoreDisplay();

        // Start the coroutine to update the score periodically
        StartCoroutine(UpdateScoreCoroutine());
    }

    IEnumerator UpdateScoreCoroutine()
    {
        // Update the score once per second
        while (true)
        {
            // Access the global score variable and update the local score
            score = GlobalVariables.score;

            // Update the score display
            UpdateScoreDisplay();

            yield return new WaitForSeconds(1f); // Wait for 1 second before updating again
        }
    }

    void UpdateScoreDisplay()
    {
        // Update the text of the TextMeshProUGUI component with the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("Score text reference is not set!");
        }
    }
}
